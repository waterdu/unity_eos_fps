using Epic.OnlineServices;
using Oka.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Oka.App
{
    public abstract class Ctrl
    {
        public static Dictionary<ProductUserId, Ctrl> idToCtrl = new Dictionary<ProductUserId, Ctrl>();

        public ProductUserId userId;
        public Chr chr = null;
        public bool isRequestDestroy = false;

        public Ctrl(ProductUserId userId) => this.userId = userId;

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

        public static void RequestDestroy(ProductUserId userId)
        {
            if (idToCtrl.Keys.ToList().Exists(e => e.InnerHandle == userId.InnerHandle) == false)
            {
                idToCtrl[userId].isRequestDestroy = true;
                return;
            }
            Debug.LogError("User not found:" + userId.InnerHandle);
        }

        protected virtual void Respawn()
        {
            chr = Object.Instantiate(App.chrPrefab);
            chr.transform.localPosition = new Vector3(Random.Range(1, 3), 1.5f, Random.Range(1, 3));
        }

        protected virtual void Tick()
        {
        }

        public virtual void ReceivePacket(PacketData data)
        {
        }

        public void Destroy()
        {
            if (chr != null)
            {
                Object.Destroy(chr.gameObject);
            }
        }
    }
}
