using Oka.Common;
using System.Collections.Generic;
using UnityEngine;


namespace App
{
    /// <summary>
    /// Character control from login user input;
    /// </summary>
    public class PlayerCtrl : Ctrl
    {
        enum State
        {
            NONE = 0,
            LANDING,
            JUMPING,
        }

        Vector3 _prevMouseXy = default;

        void Start()
        {
            _prevMouseXy = Input.mousePosition;
        }

        void Update()
        {
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

            if (chr.state == MoveState.LANDING)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    chr.Jump();
                }
            }

            var bodyEu = transform.localRotation.eulerAngles;
            bodyEu.x = 0f;
            bodyEu.y += Input.GetAxis("Mouse X") / 2f / Screen.width * 4000;
            bodyEu.z = 0f;
            transform.localRotation = Quaternion.Euler(bodyEu);

            var camEu = camera.transform.localRotation.eulerAngles;
            camEu.x -= Input.GetAxis("Mouse Y") / 2f / Screen.height * 4000;
            if (dXy.y > 0 && (camEu.x < -90f && camEu.x > -180f || camEu.x < 270f && camEu.x > 180f))
            {
                camEu.x = 271f;
            }
            else if (dXy.y < 0 && camEu.x > 90f && camEu.x < 180f)
            {
                camEu.x = 89f;
            }
            camera.transform.localRotation = Quaternion.Euler(camEu);

            _prevMouseXy = mouseXy;



            if (Input.GetMouseButtonDown(0))
            {
                chr.Fire();
            }
        }
    }
}
