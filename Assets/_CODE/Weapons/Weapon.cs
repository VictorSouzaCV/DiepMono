using DiepMono.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DiepMono.Weapons
{
    public class Weapon : MonoBehaviour
    {

        public WeaponData WeaponData;
        public GameObject BulletPrefab;
        public Transform BulletsContainer;
        [HideInInspector] public UnityEvent OnWeaponFire = new UnityEvent();
        [HideInInspector] public UnityEvent OnWeaponReload = new UnityEvent();
        Queue<GameObject> bulletPool = new Queue<GameObject>();

        float lastShotFlag;
        float ammoLeft;


        void Start()
        {
            FillBulletPool();
            Reload();
            lastShotFlag = Time.time - WeaponData.FireInterval;

        }

        void FillBulletPool()
        {
            if (WeaponData.Ammo <= 0)
                Debug.LogError("Clip size must be positive!");
            else
            {
                for (int i = 0; i < WeaponData.Ammo * 2; i++)
                {
                    GameObject newBullet = Instantiate(BulletPrefab, BulletsContainer.position, BulletPrefab.transform.rotation, BulletsContainer);
                    newBullet.GetComponent<Bullet>().Weapon = this;
                    bulletPool.Enqueue(newBullet);
                }
            }
        }


        public void Fire(Vector3 direction)
        {
            if (Time.time - lastShotFlag >= WeaponData.FireInterval
                && ammoLeft > 0)
            {
                GameObject bullet;
                try
                {
                    bullet = bulletPool.Dequeue();
                }
                catch (System.InvalidOperationException)
                {
                    Debug.LogWarning("Pool out of elements. Instantiating more bullets", gameObject);
                    FillBulletPool();
                    bullet = bulletPool.Dequeue();
                }
                bullet.GetComponent<Bullet>().FireBullet(direction);
                lastShotFlag = Time.time;
                ammoLeft--;
                OnWeaponFire.Invoke();
            }
        }

        public void Reload()
        {
            ammoLeft = WeaponData.Ammo;
            OnWeaponReload.Invoke();
        }

        public void ReturnBulletToPool(GameObject bullet)
        {
            bulletPool.Enqueue(bullet);
            bullet.transform.position = BulletsContainer.position;
            bullet.transform.SetParent(BulletsContainer);
        }
    } 
}
