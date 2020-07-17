using Epic.OnlineServices;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public abstract class Ctrl
    {
        public static List<Ctrl> list = new List<Ctrl>();

        public ProductUserId userId;
        public Chr chrPrefab = null;
        public Chr chr = null;

        public static void Manage()
        {
            foreach (var ctrl in list)
            {
                ctrl.Sync();

                if (ctrl.chr == null)
                {
                    ctrl.Spawn();
                }
            }
        }

        public static void GeneratePlayer() => list.Add(new PlayerCtrl());

        public void Spawn() => chr = Object.Instantiate(chrPrefab);

        protected abstract void Sync();
    }
}
