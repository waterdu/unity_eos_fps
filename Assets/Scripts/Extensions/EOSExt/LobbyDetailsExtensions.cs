using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;
using Oka.Common;
using System.Collections.Generic;

namespace Oka.EOSExt
{
    /// <summary>
    /// LobbySearch Extensions
    /// </summary>
    public static class LobbyDetailsExtensions
    {
        /// <summary>
        /// Short GetLobbyOwner
        /// </summary>
        /// <returns>user id</returns>
        public static ProductUserId GetLobbyOwner(this LobbyDetails detail) => detail.GetLobbyOwner(new LobbyDetailsGetLobbyOwnerOptions());

        /// <summary>
        /// Short GetMemberByIndex
        /// </summary>
        /// <returns>user id</returns>
        public static ProductUserId GetMemberByIndex(this LobbyDetails detail, uint MemberIndex)
        {
            var op = new LobbyDetailsGetMemberByIndexOptions
            {
                MemberIndex = MemberIndex
            };

            return detail.GetMemberByIndex(op);
        }

        /// <summary>
        /// Short GetMemberByIndex
        /// </summary>
        /// <returns>member count</returns>
        public static uint GetMemberCount(this LobbyDetails detail)
        {
            return detail.GetMemberCount(new LobbyDetailsGetMemberCountOptions());
        }

        /// <summary>
        /// Get member list
        /// </summary>
        /// <returns>user id list</returns>
        public static List<ProductUserId> GetMembers(this LobbyDetails detail)
        {
            var count = detail.GetMemberCount();
            var list = new List<ProductUserId>();
            for (int i = 0; i < count; i++)
            {
                list.Add(detail.GetMemberByIndex((uint)i));
            }
            return list;
        }
    }
}
