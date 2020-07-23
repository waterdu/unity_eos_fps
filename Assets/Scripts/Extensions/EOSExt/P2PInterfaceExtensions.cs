using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;
using Oka.Common;

namespace Oka.EOSExt
{
    /// <summary>
    /// P2PInterface Extensions
    /// </summary>
    public static class P2PInterfaceExtensions
    {
        /// <summary>
        /// Short SendPacket
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="socketName">Socket name</param>
        /// <param name="remoteUserId">Send to user id</param>
        /// <param name="localUserId">Login user id</param>
        /// <param name="channel">Channel id</param>
        /// <param name="data">data</param>
        public static void SendPacket(this P2PInterface p2p, string socketName, ProductUserId remoteUserId, ProductUserId localUserId, byte channel, byte[] data)
        {
            var op = new SendPacketOptions
            {
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
                RemoteUserId = remoteUserId,
                LocalUserId = localUserId,
                Channel = channel,
                Data = data
            };
            var result = p2p.SendPacket(op);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// Short AddNotifyPeerConnectionRequest
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="socketName">Socket name</param>
        /// <param name="localUserId">Login user id</param>
        public static void AddNotifyPeerConnectionRequest(this P2PInterface p2p, string socketName, ProductUserId localUserId, OnIncomingConnectionRequestCallback fun)
        {
            var op = new AddNotifyPeerConnectionRequestOptions
            {
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
                LocalUserId = localUserId,
            };

            p2p.AddNotifyPeerConnectionRequest(op, null, fun);
        }

        /// <summary>
        /// Short AddNotifyPeerConnectionClosed
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="socketName">Socket name</param>
        /// <param name="localUserId">Login user id</param>
        public static void AddNotifyPeerConnectionClosed(this P2PInterface p2p, string socketName, ProductUserId localUserId, OnRemoteConnectionClosedCallback fun)
        {
            var op = new AddNotifyPeerConnectionClosedOptions
            {
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
                LocalUserId = localUserId,
            };

            p2p.AddNotifyPeerConnectionClosed(op, null, fun);
        }

        /// <summary>
        /// Short AcceptConnection
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">Self user id</param>
        /// <param name="remoteUserId">Send from user id</param>
        /// <param name="socketName">Socket name</param>
        public static void AcceptConnection(this P2PInterface p2p, ProductUserId localUserId, ProductUserId remoteUserId, string socketName)
        {
            var accOp = new AcceptConnectionOptions
            {
                LocalUserId = localUserId,
                RemoteUserId = remoteUserId,
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
            };

            var result = p2p.AcceptConnection(accOp);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// Short GetNextReceivedPacketSize
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">Login user id</param>
        /// <param name="requestedChannel">channel id</param>
        public static uint GetNextReceivedPacketSize(this P2PInterface p2p, ProductUserId localUserId, byte requestedChannel)
        {
            var sizeOp = new GetNextReceivedPacketSizeOptions
            {
                LocalUserId = localUserId,
                RequestedChannel = requestedChannel
            };
            uint size;
            var result = p2p.GetNextReceivedPacketSize(sizeOp, out size);
            if (result != Result.Success)
            {
                // It is an error even if there is no message, so it is hidden
                //Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
            return size;
        }

        /// <summary>
        /// Short ReceivePacket
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">Login user id</param>
        /// <param name="maxDataSizeBytes">Maximum received data size</param>
        /// <param name="requestedChannel">Channel id</param>
        public static (ProductUserId, SocketId, byte, byte[], uint) ReceivePacket(this P2PInterface p2p, ProductUserId localUserId, uint maxDataSizeBytes, byte requestedChannel)
        {
            var op = new ReceivePacketOptions
            {
                LocalUserId = localUserId,
                MaxDataSizeBytes = maxDataSizeBytes,
                RequestedChannel = requestedChannel
            };

            // * An error will occur if the array is null.
            byte[] rawData = new byte[maxDataSizeBytes];
            var result = p2p.ReceivePacket(op, out ProductUserId remoteUserId, out SocketId socketId, out byte channel, ref rawData, out uint outBytesWritten);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
                return default;
            }
            return (remoteUserId, socketId, channel, rawData, outBytesWritten);
        }
    }
}
