using System.Collections.Generic;
using UnityEngine;


namespace App
{
    public class PlayerCtrl : MonoBehaviour
    {
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
        int _colCount = 0;

        void Start()
        {
            _prevMouseXy = Input.mousePosition;
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

            if (_colCount == 1)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rigid.AddForce(Vector3.up * 50, ForceMode.Acceleration);
                }
            }

            var mouseXy = Input.mousePosition;
            var dXy = mouseXy - _prevMouseXy;
            Debug.LogError(dXy);
            var bodyEu = transform.localRotation.eulerAngles;
            bodyEu.x = 0f;
            bodyEu.y += Input.GetAxis("Mouse X") / 2f;
            bodyEu.z = 0f;
            transform.localRotation = Quaternion.Euler(bodyEu);

            var camEu = camera.transform.localRotation.eulerAngles;
            camEu.x -= Input.GetAxis("Mouse Y") / 2f;
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
        }

        void OnCollisionEnter(Collision collision)
        {
            _state = State.LANDING;
            _colCount++;
        }

        void OnCollisionExit(Collision collision)
        {
            _state = State.JUMPING;
            _colCount--;
        }

        void Reset()
        {
            rigid = gameObject.GetComponent<Rigidbody>();
            camera = gameObject.GetComponentInChildren<Camera>();
        }
    }
}
