using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;
using Oka.Common;

namespace Oka.EOSExt
{
    /// <summary>
    /// LobbyInterface Extensions
    /// </summary>
    public static class LobbyInterfaceExtensions
    {
        /// <summary>
        /// Async CreateLobby
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="localUserId">Login user id</param>
        /// <param name="maxLobbyMembers">Max member count</param>
        /// <param name="permissionLevel">Public settings, etc.</param>
        /// <returns>Task</returns>
        public static async UniTask<CreateLobbyCallbackInfo> CreateLobby(this LobbyInterface lobby, ProductUserId localUserId, uint maxLobbyMembers, LobbyPermissionLevel permissionLevel)
        {
            var lobbyOp = new CreateLobbyOptions
            {
                LocalUserId = localUserId,
                MaxLobbyMembers = maxLobbyMembers,
                PermissionLevel = permissionLevel,
            };
            CreateLobbyCallbackInfo info = null;
            lobby.CreateLobby(lobbyOp, null, e =>
            {
                info = e;
            });
            while (info == null)
            {
                await UniTask.NextFrame();
            }

            if (info.ResultCode == Result.Success)
            {
                return info;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{info.ResultCode}");
            return null;
        }

        /// <summary>
        /// Short UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="localUserId">Login user id</param>
        /// <param name="LobbyId">Lobby id</param>
        /// <returns>Handle</returns>
        public static LobbyModification UpdateLobbyModification(this LobbyInterface lobby, ProductUserId localUserId, string lobbyId)
        {
            var modOp = new UpdateLobbyModificationOptions
            {
                LocalUserId = localUserId,
                LobbyId = lobbyId
            };

            LobbyModification handle;
            var result = lobby.UpdateLobbyModification(modOp, out handle);
            if (result == Result.Success)
            {
                return handle;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }

        /// <summary>
        /// Short UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="maxResults">Max search count</param>
        /// <returns>Lobby search instance</returns>
        public static LobbySearch CreateLobbySearch(this LobbyInterface lobby, uint maxResults)
        {
            var lobbyOp = new CreateLobbySearchOptions
            {
                MaxResults = maxResults
            };

            LobbySearch search;
            var result = lobby.CreateLobbySearch(lobbyOp, out search);
            if (result == Result.Success)
            {
                return search;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }

        /// <summary>
        /// Async JoinLobby
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="lobbyDetailsHandle">Lobby detail</param>
        /// <param name="localUserId">Login user id</param>
        /// <returns>Task</returns>
        public static async UniTask<JoinLobbyCallbackInfo> JoinLobby(this LobbyInterface lobby, LobbyDetails lobbyDetailsHandle, ProductUserId localUserId)
        {
            var joinOp = new JoinLobbyOptions
            {
                LobbyDetailsHandle = lobbyDetailsHandle,
                LocalUserId = localUserId
            };
            JoinLobbyCallbackInfo info = null;
            lobby.JoinLobby(joinOp, null, e =>
            {
                info = e;
            });
            while (info == null)
            {
                await UniTask.NextFrame();
            }

            if (info.ResultCode == Result.Success)
            {
                return info;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{info.ResultCode}");
            return null;
        }
    }
}
