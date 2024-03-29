﻿using UnityEngine;
using Oka.Common;

namespace Oka.App
{
    /// <summary>
    /// Character compoonent
    /// </summary>
    public class Chr : MonoBehaviour
    {
        public Rigidbody rigid = null;
        public new Camera camera = null;
        public Gun gun = null;
        public Foot foot = null;
        public MoveState state => foot.state;
        public bool isDamage = false;

        /// <summary>
        /// Character Manipulate 
        /// </summary>
        /// <param name="chrPos">Chara Position</param>
        /// <param name="chrRot">Chara Rotation</param>
        /// <param name="cameraRot">Camera Rotation</param>
        /// <param name="isFire">true : Gun Fire</param>
        public void Manipulate(Vector3 chrPos, float chrRot, float cameraRot, bool isFire)
        {
            transform.localPosition = chrPos;
            transform.localEulerAngles = new Vector3(0, chrRot, 0);
            camera.transform.localEulerAngles = new Vector3(cameraRot, 0, 0);
            if (isFire)
            {
                gun.Fire();
            }
        }

        /// <summary>
        /// Jump action
        /// </summary>
        public void Jump()
        {
            rigid?.AddForce(Vector3.up * 20f, ForceMode.Acceleration);
        }

        /// <summary>
        /// Collision Enter
        /// </summary>
        /// <param name="col">collision</param>
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<Bullet>() != null)
            {
                isDamage = true;
            }
        }

        /// <summary>
        /// Collision Exit
        /// </summary>
        /// <param name="col">collision</param>
        void OnCollisionExit(Collision col)
        {
        }

        /// <summary>
        /// Reset component
        /// </summary>
        void Reset()
        {
            rigid = gameObject.GetComponent<Rigidbody>();
            camera = gameObject.GetComponentInChildren<Camera>();
        }
    }
}
