using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// App component
    /// </summary>
    public class App : MonoBehaviour
    {
        public static App ins = null;

        [SerializeField]
        Chr _chrPrefab = null;
        public static Chr chrPrefab => ins._chrPrefab;

        /// <summary>
        /// First frame
        /// </summary>
        void Start()
        {
            ins = this;
        }

        /// <summary>
        /// Every frame
        /// </summary>
        void Update()
        {
            Ctrl.Manage();
        }
    }
}
