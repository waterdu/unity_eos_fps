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
                if (ctrl.chr == null)
                {
                    ctrl.Spawn();
                }
                ctrl.Tick();
            }
        }

        public static void GeneratePlayer() => list.Add(new PlayerCtrl());

        public void Spawn()
        {
            Initialize();

            chr = Object.Instantiate(App.chrPrefab);
            chr.transform.localPosition = new Vector3(Random.Range(1, 3), 1, Random.Range(1, 3));
        }

        public abstract void Initialize();

        public abstract void Tick();
    }
}
