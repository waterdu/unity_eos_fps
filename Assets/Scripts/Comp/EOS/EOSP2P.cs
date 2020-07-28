using Oka.App;
using Cysharp.Threading.Tasks;
using EOSCommon;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Lobby;
using Oka.Common;
using Oka.EOSExt;
using UnityEngine;
using UnityEngine.Networking;
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
        /// First frame
        /// </summary>
        void Start()
        {
            _ins = this;
        }

        /// <summary>
        /// Every frame
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

            // Set request callback
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

            var search = lobby.CreateLobbySearch(1);
            if (search == null)
            {
                return;
            }

            search.SetParameter("name", true, ComparisonOp.Equal);

            var isJoinLobby = false;
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
                        EOS.lobbyId = info.LobbyId;
                        foreach (var userId in detail.GetMembers())
                        {
                            if (userId.InnerHandle != PlayerCtrl.userId.InnerHandle)
                            {
                                Ctrl.GenerateNetCtrl(userId);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Error join lobby");
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

            // TODO : Lobby search is not working. No need to add.
            handle.AddAttribute("name", true, LobbyAttributeVisibility.Public);

            var info = await lobby.UpdateLobby(handle);

            EOS.lobbyId = info.LobbyId;
            Debug.LogError("lobbyId:" + EOS.lobbyId);
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
    }
}
