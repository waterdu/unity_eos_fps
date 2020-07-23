using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Lobby;
using Oka.Common;

namespace Oka.EOSExt
{
    /// <summary>
    /// LobbySearch Extensions
    /// </summary>
    public static class LobbySearchExtensions
    {
        /// <summary>
        /// Short SetParameter
        /// </summary>
        /// <param name="search">LobbySearch</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="comparisonOp">Compare option</param>
        public static void SetParameter(this LobbySearch search, string key, AttributeDataValue value, ComparisonOp comparisonOp)
        {
            var attr = new AttributeData();
            attr.Key = key;
            attr.Value = value;
            var paramOp = new LobbySearchSetParameterOptions
            {
                Parameter = attr,
                ComparisonOp = comparisonOp,
            };
            var result = search.SetParameter(paramOp);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// Short SetLobbyId
        /// </summary>
        /// <param name="search">LobbySearch</param>
        /// <param name="lobbyId">Lobby id</param>
        public static void SetLobbyId(this LobbySearch search, string lobbyId)
        {
            var op = new LobbySearchSetLobbyIdOptions
            {
                LobbyId = lobbyId
            };
            var result = search.SetLobbyId(op);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// Async Find 
        /// </summary>
        /// <param name="search">LobbySearch</param>
        /// <param name="localUserId">Login user id</param>
        /// <returns>Task</returns>
        public static async UniTask<LobbySearchFindCallbackInfo> Find(this LobbySearch search, ProductUserId localUserId)
        {
            var op = new LobbySearchFindOptions
            {
                LocalUserId = localUserId
            };
            LobbySearchFindCallbackInfo info = null;
            search.Find(op, null, e =>
            {
                info = e;
            });

            while (info == null || info.ResultCode == Result.OperationWillRetry)
            {
                if (info != null)
                {
                    Debug.LogError($"error {DebugTools.GetClassMethodName()}:{info.ResultCode}");
                    info = null;
                }
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
        /// Short GetSearchResultCount
        /// </summary>
        /// <param name="search">LobbySearch</param>
        /// <returns>Result count</returns>
        public static uint GetSearchResultCount(this LobbySearch search) => search.GetSearchResultCount(new LobbySearchGetSearchResultCountOptions());

        /// <summary>
        /// Short GetSearchResultCount
        /// </summary>
        /// <param name="search">LobbySearch</param>
        /// <param name="localUserId">Login user id</param>
        public static LobbyDetails CopySearchResultByIndex(this LobbySearch search, uint lobbyIndex)
        {
            var resOp = new LobbySearchCopySearchResultByIndexOptions
            {
                LobbyIndex = lobbyIndex
            };
            var result = search.CopySearchResultByIndex(resOp, out LobbyDetails detail);
            if (result == Result.Success)
            {
                return detail;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }
    }
}
