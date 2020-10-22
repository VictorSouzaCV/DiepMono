using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public BulletData BulletData;
    [HideInInspector] public Weapon Weapon;
    float timeShot;

    void OnCollisionEnter(Collision col)
    {
        IDamageable target = col.collider.GetComponent<IDamageable>();
        if(target != null)
            target.TakeDamage(BulletData.Damage);
        DestroyBullet();
    }

    public void FireBullet(Vector3 direction)
    {
        transform.SetParent(null);
        gameObject.SetActive(true);
        timeShot = Time.time;
        StartCoroutine(MoveBullet(direction));
    }

    IEnumerator MoveBullet(Vector3 moveDirection)
    {
        while(true)
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
