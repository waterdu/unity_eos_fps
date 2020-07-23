using Epic.OnlineServices;
using Oka.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// Character ctrl
    /// </summary>
    public abstract class Ctrl
    {
        public static Dictionary<ProductUserId, Ctrl> idToCtrl = new Dictionary<ProductUserId, Ctrl>();

        public ProductUserId userId;
        public Chr chr = null;
        public bool isRequestDestroy = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userId">user id</param>
        public Ctrl(ProductUserId userId) => this.userId = userId;

        /// <summary>
        /// Manage in every frame
        /// </summary>
        public static void Manage()
        {
            var userIds = idToCtrl.Keys.ToList();
            for (int i = userIds.Count - 1; i >= 0; i--)
            {
                var userId = userIds[i];
                var ctrl = idToCtrl[userId];
                if (ctrl.isRequestDestroy)
                {
                    ctrl.Destroy();
                    idToCtrl.Remove(userId);
                }
                else
                {
                    if (ctrl.chr == null)
                    {
                        ctrl.Respawn();
                    }
                    ctrl.Tick();
                }
            }
        }

        /// <summary>
        /// Generate player control
        /// </summary>
        /// <param name="userId">Local user id</param>
        public static void GeneratePlayer(ProductUserId userId)
        {
            if (idToCtrl.Keys.ToList().Exists(e => e.InnerHandle == userId.InnerHandle) == false)
            {
                Debug.LogError("Generate Player:" + userId.InnerHandle);
                idToCtrl[userId] = new PlayerCtrl(userId);
                return;
            }
            Debug.LogError("User already login:" + userId.InnerHandle);
        }

        /// <summary>
        /// Generate network control
        /// </summary>
        /// <param name="userId">Remote user id</param>
        public static void GenerateNetCtrl(ProductUserId userId)
        {
            if (idToCtrl.Keys.ToList().Exists(e => e.InnerHandle == userId.InnerHandle) == false)
            {
                Debug.LogError("Generate Npc:" + userId.InnerHandle);
                idToCtrl[userId] = new NetCtrl(userId);
                return;
            }
            Debug.LogError("User already login:" + userId.InnerHandle);
        }

        /// <summary>
        /// Destroy request
        /// </summary>
        /// <param name="userId">User id</param>
        public static void RequestDestroy(ProductUserId userId)
        {
            if (idToCtrl.Keys.ToList().Exists(e => e.InnerHandle == userId.InnerHandle) == false)
            {
                idToCtrl[userId].isRequestDestroy = true;
                return;
            }
            Debug.LogError("User not found:" + userId.InnerHandle);
        }

        /// <summary>
        /// On respawn
        /// </summary>
        protected virtual void Respawn()
        {
            chr = Object.Instantiate(App.chrPrefab);
            chr.transform.localPosition = new Vector3(Random.Range(1, 3), 1.5f, Random.Range(1, 3));
        }

        /// <summary>
        /// On every frame
        /// </summary>
        protected virtual void Tick()
        {
        }

        /// <summary>
        /// On receive packet
        /// </summary>
        public virtual void ReceivePacket(PacketData data)
        {
        }

        /// <summary>
        /// Destroy
        /// </summary>
        public void Destroy()
        {
            if (chr != null)
            {
                Object.Destroy(chr.gameObject);
            }
        }
    }
}
