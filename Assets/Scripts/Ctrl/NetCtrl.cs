using Epic.OnlineServices;
using Oka.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// Character Control from network;
    /// </summary>
    public class NetCtrl : Ctrl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userId">remote user id</param>
        public NetCtrl(ProductUserId userId) : base(userId)
        {
        }

        /// <summary>
        /// On Respawn
        /// </summary>
        protected override void Respawn()
        {
            base.Respawn();

            Object.Destroy(chr.gameObject.GetComponent<Rigidbody>());
            chr.camera.enabled = false;
        }


        /// <summary>
        /// On Receive Packet
        /// </summary>
        /// <param name="data">packet data</param>
        public override void ReceivePacket(PacketData data)
        {
            chr.Manipulate(data.position, data.rotX, data.rotY, data.isFire > 0);
        }
    }
}
