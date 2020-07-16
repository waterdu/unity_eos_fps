using UnityEngine;

namespace App
{
    public class Bullet : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            transform.localPosition += transform.up * Time.deltaTime * 20;
            if (Mathf.Abs(transform.localPosition.x) > 1000 || Mathf.Abs(transform.localPosition.y) > 1000 || Mathf.Abs(transform.localPosition.z) > 1000)
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
