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
        public GameObject rootContent = null;

        public Button btnAuthLogin = null;

        public TMP_InputField inptDevPort = null;
        public TMP_InputField inptDevName = null;
        public Button btnDevLogin = null;

        public Button btnGithub = null;
        public static bool isLockMouse = true;

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {
            btnAuthLogin.SetOnClick(() => EOSP2P.LoginAuth().Forget());
            btnDevLogin.SetOnClick(() => EOSP2P.LoginDev(inptDevPort.text.ToInt(), inptDevName.text).Forget());
            btnGithub.SetOnClick(() => Application.OpenURL("https://github.com/okamototomoyuki/unity_eos_fps"));
        }

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            if (PlayerCtrl.userId == null)
            {
                rootContent.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                rootContent.SetActive(false);

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
