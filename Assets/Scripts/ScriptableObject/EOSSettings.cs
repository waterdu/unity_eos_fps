using UnityEngine;
namespace EOSCommon
{
    /// <summary>
    /// EOS Setting
    /// </summary>
    [CreateAssetMenu(fileName = "EOSSettings", menuName = "ScriptableObjects/EOSSettings", order = 1)]
    public class EOSSettings : ScriptableObject
    {
        [Header("EOS")]
        public string productName;
        public string productVersion;
        public string clientId;
        public string clientSecret;
        public string productId;
        public string sandboxId;
        public string deploymentId;

        [Header("P2P")]
        public string socketName = "P2PSocket";
        public byte channelId = 1;

        [Header("Temporary lobby server")]
        public string apiUrl;
        public string apiSecret;
    }
}