using Oka.Common;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;


namespace App
{
    /// <summary>
    /// Character control from login user input;
    /// </summary>
    public class PlayerCtrl : Ctrl
    {
        public int hp = 0;

        public override void Initialize()
        {
            hp = 3;
        }

        public override void Tick()
        {
            if (chr.isDamage)
            {
                hp--;
                if (hp == 0)
                {
                    chr.DestroyNotNull();
                }
                chr.isDamage = false;
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

            var bodyEu = chr.transform.localRotation.eulerAngles;
            bodyEu.x = 0f;
            bodyEu.y += dx;
            bodyEu.z = 0f;
            var bodyRot = Quaternion.Euler(bodyEu);

            var camEu = chr.camera.transform.localRotation.eulerAngles;
            camEu.x -= dy;
            camEu.y = 0;
            camEu.z = 0;
            if (dy > 0 && (camEu.x < -90f && camEu.x > -180f || camEu.x < 270f && camEu.x > 180f))
            {
                camEu.x = 271f;
            }
            else if (dy < 0 && camEu.x > 90f && camEu.x < 180f)
            {
                camEu.x = 89f;
            }
            var camRot = Quaternion.Euler(camEu);

            var isFire = false;
            if (Input.GetMouseButtonDown(0))
            {
                isFire = true;
            }
            chr.Manipulate(chrPos, bodyRot, camRot, isFire);


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
