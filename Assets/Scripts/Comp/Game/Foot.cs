using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// Foot Compoonent
    /// </summary>
    public class Foot : MonoBehaviour
    {
        public MoveState state = MoveState.NONE;

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

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                state = MoveState.JUMPING;
            }
        }
    }
}
