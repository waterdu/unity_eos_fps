using Oka.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    /// <summary>
    /// Character Control from network;
    /// </summary>
    public class NetCtrl : Ctrl
    {
        /// <summary>
        /// First frame
        /// </summary>
        void Start()
        {
            // Not use Rigidbody;
            chr.GetComponent<Rigidbody>().DestroyNotNull();
        }

        /// <summary>
        /// Every frame
        /// </summary>
        void Update()
        {

        }

        protected override void Sync()
        {
        }
    }
}
