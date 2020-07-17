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

        Vector3 _prevMouseXy = default;
        int _colCount = 0;

        /// <summary>
        /// Chara and Camera Transform update
        /// </summary>
        /// <param name="chrPos">Chara Position</param>
        /// <param name="chrRot">Chara Rotation</param>
        /// <param name="cameraRot">Camera Rotation</param>
        public void UpdateTransform(Vector3 chrPos, Quaternion chrRot, Quaternion cameraRot)
        {
            transform.position = chrPos;
            transform.rotation = chrRot;
            camera.transform.rotation = cameraRot;
        }

        /// <summary>
        /// Gun Fire
        /// </summary>
        public void Fire() => gun.Fire();

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
                Destroy(this.gameObject);
                return;
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
