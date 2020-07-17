using UnityEngine;

namespace App
{
    /// <summary>
    /// Character Compoonent
    /// </summary>
    public class Chr : MonoBehaviour
    {
        public Rigidbody rigid = null;
        public Camera camera = null;
        public Gun gun = null;
        public MoveState state = MoveState.JUMPING;
        public bool isDamage = false;

        Vector3 _prevMouseXy = default;
        int _colCount = 0;

        /// <summary>
        /// Character Manipulate 
        /// </summary>
        /// <param name="chrPos">Chara Position</param>
        /// <param name="chrRot">Chara Rotation</param>
        /// <param name="cameraRot">Camera Rotation</param>
        /// <param name="isFire">true : Gun Fire</param>
        public void Manipulate(Vector3 chrPos, Quaternion chrRot, Quaternion cameraRot, bool isFire)
        {
            transform.localPosition = chrPos;
            transform.localRotation = chrRot;
            camera.transform.localRotation = cameraRot;
            if (isFire)
            {
                gun.Fire();
            }
        }

        public void Jump()
        {
            rigid?.AddForce(Vector3.up * 50, ForceMode.Acceleration);
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
            state = MoveState.LANDING;
            _colCount++;
        }

        /// <summary>
        /// Collision Exit
        /// </summary>
        /// <param name="col">collision</param>
        void OnCollisionExit(Collision col)
        {
            state = MoveState.JUMPING;
            _colCount--;
        }

        void Reset()
        {
            rigid = gameObject.GetComponent<Rigidbody>();
            camera = gameObject.GetComponentInChildren<Camera>();
        }
    }
}
