using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// Foot compoonent
    /// </summary>
    public class Foot : MonoBehaviour
    {
        public MoveState state = MoveState.NONE;

        /// <summary>
        /// On collide start
        /// </summary>
        /// <param name="other">other collider</param>
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                state = MoveState.LANDING;
            }
            if (other.gameObject.CompareTag("Deadzone"))
            {
                PlayerCtrl.hp = 0;
            }
        }

        /// <summary>
        /// On collide end
        /// </summary>
        /// <param name="other">other collider</param>
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                state = MoveState.JUMPING;
            }
        }
    }
}
