using DiepMono.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace DiepMono.UI
{
    public class AmmoUI : MonoBehaviour
    {
        Weapon Weapon;
        Queue<GameObject> bulletPool = new Queue<GameObject>();

        void Start()
        {
            Weapon = GetComponentInParent<Weapon>();
            Weapon.OnWeaponFire.AddListener(SpendAmmo);
            Weapon.OnWeaponReload.AddListener(RefillAmmo);
            SetAmmo();
        }

        void SetAmmo()
        {
            foreach (Transform child in transform)
            {
                bulletPool.Enqueue(child.gameObject);
            }
        }

        public void SpendAmmo()
        {
            GameObject spentBullet = bulletPool.Dequeue();
            spentBullet.SetActive(false);
        }

        public void RefillAmmo()
        {
            bulletPool.Clear();
            foreach (Transform child in transform)
            {
                bulletPool.Enqueue(child.gameObject);
                child.gameObject.SetActive(true);
            }
        }
    } 
}
