using Oka.App;
using Cysharp.Threading.Tasks;
using EOSCommon;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Lobby;
using Oka.Common;
using Oka.EOSExt;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Epic.OnlineServices;

namespace EOSFps
{
    /// <summary>
    /// P2P Processing
    /// </summary>
    public class EOSP2P : MonoBehaviour
    {
        static EOSP2P _ins = null;

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {
            _ins = this;
        }

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            var p2p = EOS.p2p;

            var playerUserId = PlayerCtrl.userId;
            if (playerUserId != null)
            {
                var size = p2p.GetNextReceivedPacketSize(playerUserId, EOS.channelId);
                if (size > 0)
                {
                    var (remoteUserId, _, _, rawData, _) = p2p.ReceivePacket(playerUserId, size, EOS.channelId);
                    //Debug.LogError($"Rec from:{remoteUserId.InnerHandle} player:{playerUserId.InnerHandle}");
                    Ctrl.idToCtrl[remoteUserId].ReceivePacket(MarshalTools.Deserialize<PacketData>(rawData));
                }
            }
        }

        /// <summary>
        /// Login by EOS Dev Auth Tool
        /// </summary>
        /// <returns>Task</returns>
        public static async UniTask LoginDev(int devPort, string devName)
        {
            var auth = EOS.auth;
            var authRes = await auth.Login(LoginCredentialType.Developer, $"localhost:{devPort}", devName);
            if (authRes == null)
            {
                return;
            }

            await _Login(authRes);
        }


        /// <summary>
        /// Login by browser auth
        /// </summary>
        /// <returns>Task</returns>
        public static async UniTask LoginAuth()
        {
            var auth = EOS.auth;

            var refreshToken = SaveDataUtils.GetString(Defines.KEY_REFRESH_TOKEN);
            LoginCallbackInfo authRes = null;
            if (refreshToken.NotEmpty())
            {
                authRes = await auth.Login(LoginCredentialType.RefreshToken, string.Empty, refreshToken);
            }

            if (authRes == null)
            {
                authRes = await auth.Login(LoginCredentialType.AccountPortal, string.Empty, string.Empty);
                if (authRes == null)
                {
                    return;
                }
            }

            await _Login(authRes);
        }

        /// <summary>
        /// Login by browser auth
        /// </summary>
        /// <returns>Task</returns>
        static async UniTask _Login(LoginCallbackInfo authRes)
        {
            var auth = EOS.auth;
            var con = EOS.connect;

            var token = auth.CopyUserAuthToken(authRes.LocalUserId);
            if (token == null)
            {
                return;
            }

            var conRes = await con.Login(token.AccessToken, Epic.OnlineServices.Connect.ExternalCredentialType.Epic);
            if (conRes == null)
            {
                return;
            }

            SaveDataUtils.SaveString(Defines.KEY_REFRESH_TOKEN, token.RefreshToken);
            var playerId = conRes.LocalUserId;

            Ctrl.GeneratePlayer(playerId);

            // set request callback
            _ins._SetRequestCallback();

            await _ins._JoinLobby();
        }

        /// <summary>
        /// Join Lobby 
        /// </summary>
        /// <returns>Task</returns>
        async UniTask _JoinLobby()
        {
            var lobby = EOS.lobby;


            // Get Lobby ID 
            // TODO Lobby search on EOS is not working properly.
            EOS.lobbyId = await _GetLobbyId();

            var isJoinLobby = false;
            if (EOS.lobbyId.NotEmpty())
            {
                var search = lobby.CreateLobbySearch(1);
                if (search == null)
                {
                    return;
                }

                //search.SetParameter("name", true, ComparisonOp.Equal);
                search.SetLobbyId(EOS.lobbyId);

                var result = await search.Find(PlayerCtrl.userId);
                if (result != null)
                {
                    var count = search.GetSearchResultCount();
                    if (count > 0)
                    {
                        isJoinLobby = true;

                        var detail = search.CopySearchResultByIndex(0);
                        var info = await lobby.JoinLobby(detail, PlayerCtrl.userId);
                        if (info != null)
                        {
                            foreach (var userId in detail.GetMembers())
                            {
                                if (userId.InnerHandle != PlayerCtrl.userId.InnerHandle)
                                {
                                    //Debug.LogError("login:" + userId.InnerHandle);
                                    Ctrl.GenerateNetCtrl(userId);
                                }
                                //Debug.LogError("skip:" + userId.InnerHandle);
                            }
                        }
                        else
                        {
                            // TODO error join lobby
                            Debug.LogError("Error join lobby");
                        }
                    }
                }
            }

            if (isJoinLobby == false)
            {
                await _CreateLobby();
            }
        }

        /// <summary>
        /// Create Lobby 
        /// </summary>
        /// <returns>Task</returns>
        async UniTask _CreateLobby()
        {
            var lobby = EOS.lobby;

            var result = await lobby.CreateLobby(PlayerCtrl.userId, 50, LobbyPermissionLevel.Publicadvertised);
            if (result == null)
            {
                return;
            }

            var handle = lobby.UpdateLobbyModification(PlayerCtrl.userId, result.LobbyId);

            // TODO 検索は機能していないが検索条件付与
            handle.AddAttribute("name", true, LobbyAttributeVisibility.Public);

            EOS.lobbyId = result.LobbyId;
            Debug.LogError("lobbyId:" + EOS.lobbyId);
            await _SendLobbyId(EOS.lobbyId);
        }

        /// <summary>
        /// Send Packet
        /// </summary>
        /// <param name="bytes">packet data</param>
        public static void Send(byte[] bytes)
        {
            var p2p = EOS.p2p;
            foreach (var kv in Ctrl.idToCtrl)
            {
                if (PlayerCtrl.userId != kv.Key)
                {
                    //Debug.LogError($"Send to:{kv.Key.InnerHandle} player:{PlayerCtrl.userId.InnerHandle}");
                    p2p.SendPacket(EOS.socketName, kv.Key, PlayerCtrl.userId, EOS.channelId, bytes);
                }
            }
        }

        /// <summary>
        /// Set callback for P2P requests
        /// </summary>
        void _SetRequestCallback()
        {
            var p2p = EOS.p2p;
            p2p.AddNotifyPeerConnectionRequest(EOS.socketName, PlayerCtrl.userId, e =>
            {
                Debug.LogError($"Request:Local:{e.RemoteUserId.InnerHandle} Remote:{e.RemoteUserId.InnerHandle} Player:{PlayerCtrl.userId.InnerHandle}");
                p2p.AcceptConnection(e.LocalUserId, e.RemoteUserId, e.SocketId.SocketName);
                Ctrl.GenerateNetCtrl(e.RemoteUserId);
            });

            p2p.AddNotifyPeerConnectionClosed(EOS.socketName, PlayerCtrl.userId, e =>
            {
                Debug.LogError($"Closed:Local:{e.RemoteUserId.InnerHandle} Remote:{e.RemoteUserId.InnerHandle} Player:{PlayerCtrl.userId.InnerHandle}");
                Ctrl.RequestDestroy(e.RemoteUserId);
            });
        }


        /// <summary>
        /// Send Lobby Id To Tempolary Server
        /// </summary>
        /// <returns>Task</returns>
        /// <param name="lobbyId">lobby id</param>
        async UniTask _SendLobbyId(string lobbyId)
        {
            var form = new WWWForm();
            form.AddField("v", lobbyId);
            using (var req = UnityWebRequest.Post($"{EOS.apiUrl}?secret={EOS.apiSecret}", form))
            {
                try
                {
                    await req.SendWebRequest();
                }
                catch (UnityWebRequestException)
                {
                }
            }
        }

        /// <summary>
        /// Get Lobby Id From Tempolary Server
        /// </summary>
        /// <returns>Task</returns>
        async UniTask<string> _GetLobbyId()
        {
            using (var req = UnityWebRequest.Get($"{EOS.apiUrl}?secret={EOS.apiSecret}"))
            {
                try
                {
                    await req.SendWebRequest();
                    return req.downloadHandler?.text;
                }
                catch (UnityWebRequestException)
                {
                }
                return null;
            }
        }
    }
}
