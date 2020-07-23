using Oka.App;
using Cysharp.Threading.Tasks;
using EOSCommon;
using Oka.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using EOSFps;
using System;

namespace Oka.App
{
    /// <summary>
    /// UI component
    /// </summary>
    public class UI : MonoBehaviour
    {
        public GameObject loginRoot = null;

        public Button btnAuthLogin = null;

        public TMP_InputField inptDevPort = null;
        public TMP_InputField inptDevName = null;
        public Button btnDevLogin = null;

        public Button btnGithub = null;


        public GameObject inGameRoot = null;
        public TextMeshProUGUI lblLobbyId = null;
        public TextMeshProUGUI lblUserCount = null;
        public TextMeshProUGUI lblHp = null;

        public static bool isLockMouse = true;

        /// <summary>
        /// First frame
        /// </summary>
        void Start()
        {
            btnAuthLogin.SetOnClick(() => EOSP2P.LoginAuth().Forget());
            btnDevLogin.SetOnClick(() => EOSP2P.LoginDev(inptDevPort.text.ToInt(), inptDevName.text).Forget());
            btnGithub.SetOnClick(() => Application.OpenURL("https://github.com/okamototomoyuki/unity_eos_fps"));
        }

        /// <summary>
        /// Every frame
        /// </summary>
        void Update()
        {
            if (PlayerCtrl.userId == null)
            {
                loginRoot.SetActive(true);
                inGameRoot.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                loginRoot.SetActive(false);
                inGameRoot.SetActive(true);

                var numDot = DateTime.Now.Second % 3;
                var lobbyIdText = EOS.lobbyId == null ? "Connecting." + new string('.', numDot) : EOS.lobbyId;
                lblLobbyId.text = $"Lobby Id : {lobbyIdText}";
                lblUserCount.text = $"User Count : {Ctrl.idToCtrl.Keys.Count}";
                lblHp.text = $"HP : {PlayerCtrl.hp}/{PlayerCtrl.MAX_HP}";

                loginRoot.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isLockMouse = false;
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    isLockMouse = true;
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
