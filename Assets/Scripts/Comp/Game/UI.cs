using Oka.App;
using Cysharp.Threading.Tasks;
using EOSCommon;
using Oka.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using EOSFps;

namespace Oka.App
{
    /// <summary>
    /// UI
    /// </summary>
    public class UI : MonoBehaviour
    {
        public Canvas canvas = null;

        public Button btnAuthLogin = null;

        public TMP_InputField inptDevPort = null;
        public TMP_InputField inptDevName = null;
        public Button btnDevLogin = null;
        public static bool isLockMouse = true;

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {
            btnAuthLogin.SetOnClick(() => EOSP2P.LoginAuth().Forget());
            btnDevLogin.SetOnClick(() => EOSP2P.LoginDev(inptDevPort.text.ToInt(), inptDevName.text).Forget());
        }

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            if (PlayerCtrl.userId == null)
            {
                canvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                canvas.enabled = false;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isLockMouse = !isLockMouse;
                }

                if (isLockMouse)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}
