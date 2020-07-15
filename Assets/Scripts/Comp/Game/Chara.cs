using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


namespace Game
{
    public class Chara : MonoBehaviour
    {
        static List<Chara> list = new List<Chara>();

        enum State
        {
            NONE = 0,
            LANDING,
            JUMPING,
        }

        public Rigidbody rigid = null;
        public Camera camera = null;

        State _state = State.JUMPING;
        Vector3 _prevMouseXy = default;

        void Start()
        {
            _prevMouseXy = Input.mousePosition;
            list.Add(this);
        }

        void Update()
        {
            var isMove = false;
            var vec = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                isMove = true;
                vec += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                isMove = true;
                vec += transform.forward * -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                isMove = true;
                vec += transform.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                isMove = true;
                vec += transform.right * -1;
            }
            if (isMove)
            {
                vec.y = 0f;
                vec = vec.normalized * Time.deltaTime * 5;
                transform.position += vec;
            }

            if (_state == State.LANDING)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rigid.AddForce(Vector3.up * 50, ForceMode.Acceleration);
                }
            }

            var mouseXy = Input.mousePosition;
            var dXy = mouseXy - _prevMouseXy;
            var bodyEu = transform.localRotation.eulerAngles;
            bodyEu.x = 0f;
            bodyEu.y += dXy.x / 8f;
            bodyEu.z = 0f;
            transform.localRotation = Quaternion.Euler(bodyEu);

            var camEu = camera.transform.localRotation.eulerAngles;
            camEu.x -= dXy.y / 8f;
            if (dXy.y > 0 && (camEu.x < -90f && camEu.x > -180f || camEu.x < 270f && camEu.x > 180f))
            {
                Debug.LogError(camEu.x);
                camEu.x = 271f;
            }
            else if (dXy.y < 0 && camEu.x > 90f && camEu.x < 180f)
            {
                camEu.x = 89f;
            }
            //camEu.x = Mathf.Clamp(camEu.x, -89f, 89f);
            //camEu.y = 0f;
            //camEu.z = 0f;
            camera.transform.localRotation = Quaternion.Euler(camEu);

            _prevMouseXy = mouseXy;

        }

        void OnCollisionEnter(Collision collision)
        {
            _state = State.LANDING;
        }

        void OnCollisionExit(Collision collision)
        {
            _state = State.JUMPING;
        }

        void Reset()
        {
            rigid = gameObject.GetComponent<Rigidbody>();
        }
    }
}
