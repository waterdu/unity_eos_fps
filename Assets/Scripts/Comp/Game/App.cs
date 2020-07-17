using UnityEngine;

namespace App
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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            Ctrl.GeneratePlayer();
            Ctrl.GeneratePlayer();
        }

        void Update()
        {
            Ctrl.Manage();
        }
    }
}
