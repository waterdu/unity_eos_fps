using UnityEngine;

namespace App
{
    public class App : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}
