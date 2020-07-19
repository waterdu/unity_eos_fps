using UnityEngine;

namespace Oka.App
{
    public class App : MonoBehaviour
    {
        public static App ins = null;

        [SerializeField]
        Chr _chrPrefab = null;
        public static Chr chrPrefab => ins._chrPrefab;

        void Start()
        {
            ins = this;
        }

        void Update()
        {
            Ctrl.Manage();
        }
    }
}
