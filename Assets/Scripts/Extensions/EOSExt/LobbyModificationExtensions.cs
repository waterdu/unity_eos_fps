using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;
using Oka.Common;

namespace Oka.EOSExt
{
    /// <summary>
    /// LobbyModification Extensions
    /// </summary>
    public static class LobbyModificationExtensions
    {
        /// <summary>
        /// Short UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyModification</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="visibility">Visibility type</param>
        public static void AddAttribute(this LobbyModification modify, string key, AttributeDataValue value, LobbyAttributeVisibility visibility)
        {
            var attr = new AttributeData();
            attr.Key = key;
            attr.Value = value;
            var addOp = new LobbyModificationAddAttributeOptions
            {
                Attribute = attr,
                Visibility = visibility
            };
            var addRes = modify.AddAttribute(addOp);
            if (addRes != Result.Success)
            {
                Debug.LogError($"{nameof(addRes)}:{addRes}");
            }
        }
    }
}
