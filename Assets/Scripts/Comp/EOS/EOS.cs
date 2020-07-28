using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.P2P;
using Epic.OnlineServices.Platform;
using System;
using UnityEngine;

namespace EOSCommon
{
    /// <summary>
    /// EOS Management
    /// </summary>
    public class EOS : MonoBehaviour
    {
        static EOS _ins = null;

        public EOSSettings settings = null;

        PlatformInterface m_platformInterface = null;
        public static PlatformInterface platform => _ins.m_platformInterface;
        public static AuthInterface auth => platform.GetAuthInterface();
        public static P2PInterface p2p => platform.GetP2PInterface();
        public static LobbyInterface lobby => platform.GetLobbyInterface();
        public static ConnectInterface connect => platform.GetConnectInterface();

        public static string productName => _ins.settings.productName;
        public static string productVersion => _ins.settings.productVersion;
        public static string clientId => _ins.settings.clientId;
        public static string clientSecret => _ins.settings.clientSecret;
        public static string productId => _ins.settings.productId;
        public static string sandboxId => _ins.settings.sandboxId;
        public static string deploymentId => _ins.settings.deploymentId;
        public static string socketName => _ins.settings.socketName;
        public static byte channelId => _ins.settings.channelId;

        public static string lobbyId = null;

        /// <summary>
        /// First frame
        /// </summary>
        void Start()
        {
            _ins = this;

            var initializeOptions = new InitializeOptions();
            initializeOptions.ProductName = productName;
            initializeOptions.ProductVersion = productVersion;
            var result = PlatformInterface.Initialize(initializeOptions);

            // * Unity Editor becomes AlreadyConfigured after the second time.
            if (result == Result.Success
#if UNITY_EDITOR
                || result == Result.AlreadyConfigured
#endif
                )

            {
                var clientCredentials = new ClientCredentials();
                clientCredentials.ClientId = clientId;
                clientCredentials.ClientSecret = clientSecret;

                var options = new Options();
                options.ClientCredentials = clientCredentials;
                options.ProductId = productId;
                options.SandboxId = sandboxId;
                options.DeploymentId = deploymentId;

                m_platformInterface = PlatformInterface.Create(options);
                if (m_platformInterface == null)
                {
                    throw new Exception("Failed to create platform");
                }
            }
            else
            {
                throw new Exception("Failed to initialize platform:" + result);
            }

            Debug.Log($"Login:{result}");
        }

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            m_platformInterface.Tick();
        }

        /// <summary>
        /// On Quit
        /// </summary>
        void OnApplicationQuit()
        {
            // * Does not work properly in Unity Editor.
#if !UNITY_EDITOR
            m_platformInterface?.Release();
            m_platformInterface = null;
            PlatformInterface.Shutdown();
#endif
        }
    }
}
