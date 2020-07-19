using System;
using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// P2P Data
    /// </summary>
    [Serializable]
    public struct PacketData
    {
        public Vector3 position;
        public float rotY;
        public float rotX;
        public byte isFire;
    }
}
