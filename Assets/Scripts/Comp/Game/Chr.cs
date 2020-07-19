using UnityEngine;
using Oka.Common;

namespace Oka.App
{
    /// <summary>
    /// Character Compoonent
    /// </summary>
    public class Chr : MonoBehaviour
    {
        public Rigidbody rigid = null;
        public new Camera camera = null;
        public Gun gun = null;
        public MoveState state = MoveState.JUMPING;
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
            Debug.LogError(cameraRot);
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
        }

        /// <summary>
        /// Collision Exit
        /// </summary>
        /// <param name="col">collision</param>
        void OnCollisionExit(Collision col)
        {
            state = MoveState.JUMPING;
        }

        void Reset()
        {
            rigid = gameObject.GetComponent<Rigidbody>();
            camera = gameObject.GetComponentInChildren<Camera>();
        }
    }
}
