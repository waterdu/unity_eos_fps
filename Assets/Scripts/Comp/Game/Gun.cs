using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class Gun : MonoBehaviour
    {
        public GameObject m_ancGun = null;
        public Bullet m_bulletPrefab = null;

        public void Fire()
        {
            var clone = Instantiate(m_bulletPrefab);
            clone.transform.position = m_ancGun.transform.position;
            clone.transform.rotation = m_ancGun.transform.rotation;
        }
    }
}
