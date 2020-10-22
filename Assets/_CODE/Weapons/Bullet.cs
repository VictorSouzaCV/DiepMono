using DiepMono.Data;
using DiepMono.Utils;
using System.Collections;
using UnityEngine;

namespace DiepMono.Weapons
{
    public class Bullet : MonoBehaviour
    {
        public BulletData BulletData;
        [HideInInspector] public Weapon Weapon;

        void OnCollisionEnter(Collision col)
        {
            IDamageable target = col.collider.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(BulletData.Damage);
            DestroyBullet();
        }

        public void FireBullet(Vector3 direction)
        {
            transform.SetParent(null);
            gameObject.SetActive(true);
            StartCoroutine(MoveBullet(direction));
        }

        IEnumerator MoveBullet(Vector3 moveDirection)
        {
            while (true)
            {
                transform.Translate(moveDirection * BulletData.Speed * Time.deltaTime, Space.World);
                yield return null;
            }
        }

        public void DestroyBullet()
        {
            Weapon.ReturnBulletToPool(gameObject);
            gameObject.SetActive(false);
        }
    } 
}
