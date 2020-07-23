using EOSFps;
using Epic.OnlineServices;
using Oka.Common;
using UnityEngine;


namespace Oka.App
{
    /// <summary>
    /// Character control from login user input;
    /// </summary>
    public class PlayerCtrl : Ctrl
    {
        public const int MAX_HP = 3;

        static PlayerCtrl _ins = null;
        public new static ProductUserId userId => _ins != null ? ((Ctrl)_ins).userId : null;

        public static int hp = 0;

        public PlayerCtrl(ProductUserId userId) : base(userId)
        {
            _ins = this;
        }

        /// <summary>
        /// On Respawn
        /// </summary>
        protected override void Respawn()
        {
            hp = MAX_HP;

            base.Respawn();
        }

        /// <summary>
        /// Every frame
        /// </summary>
        protected override void Tick()
        {
            if (chr.isDamage)
            {
                hp--;
                chr.isDamage = false;
            }
            if (hp == 0)
            {
                chr.DestroyNotNull();
            }

            var isMove = false;
            var chrPos = chr.GetPosition();
            var speed = 5; // TODO Temp
            if (Input.GetKey(KeyCode.W))
            {
                isMove = true;
                chrPos += chr.transform.forward * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                isMove = true;
                chrPos += chr.transform.forward * -1 * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                isMove = true;
                chrPos += chr.transform.right * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                isMove = true;
                chrPos += chr.transform.right * -1 * Time.deltaTime * speed;
            }
            if (isMove)
            {
                chr.SetPosition(chrPos);
            }

            var dx = Input.GetAxis("Mouse X") / 2f / Screen.width * 4000;
            var dy = Input.GetAxis("Mouse Y") / 2f / Screen.height * 4000;

            if (UI.isLockMouse == false)
            {
                dx = 0f;
                dy = 0f;
            }


            var bodyRot = chr.transform.localRotation.eulerAngles.y + dx;
            var camRot = chr.camera.transform.localRotation.eulerAngles.x - dy;
            if (dy > 0 && (camRot < -90f && camRot > -180f || camRot < 270f && camRot > 180f))
            {
                camRot = 271f;
            }
            else if (dy < 0 && camRot > 90f && camRot < 180f)
            {
                camRot = 89f;
            }
            chr.Manipulate(chrPos, bodyRot, camRot, Input.GetMouseButtonDown(0));

            // Send Packet
            var packet = new PacketData { position = chrPos, rotX = bodyRot, rotY = camRot, isFire = Input.GetMouseButtonDown(0) ? (byte)1 : (byte)0 };
            EOSP2P.Send(MarshalTools.Serialize(packet));

            if (chr.state == MoveState.LANDING)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    chr.Jump();
                }
            }
        }
    }
}
