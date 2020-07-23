using UnityEngine;

namespace Oka.App
{
    /// <summary>
    /// Bullet component
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// Every frame
        /// </summary>
        void Update()
        {
            transform.localPosition += transform.up * Time.deltaTime * 20;
            if (Mathf.Abs(transform.localPosition.x) > 300 || Mathf.Abs(transform.localPosition.y) > 300 || Mathf.Abs(transform.localPosition.z) > 300)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// On collide start
        /// </summary>
        void OnCollisionEnter(Collision col)
        {
            Destroy(this.gameObject);
        }
    }
}
