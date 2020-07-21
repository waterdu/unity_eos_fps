using UnityEngine;

namespace Oka.App
{
    public class Bullet : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            transform.localPosition += transform.up * Time.deltaTime * 20;
            if (Mathf.Abs(transform.localPosition.x) > 300 || Mathf.Abs(transform.localPosition.y) > 300 || Mathf.Abs(transform.localPosition.z) > 300)
            {
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision col)
        {
            Destroy(this.gameObject);
        }
    }
}
