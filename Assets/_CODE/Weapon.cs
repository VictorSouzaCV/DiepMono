using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Weapon : MonoBehaviour {	
	
	public WeaponData WeaponData;
	public GameObject BulletPrefab;
	public Transform BulletsContainer;
	Queue<GameObject> bulletPool = new Queue<GameObject>();

	[HideInInspector] public float lastShotFlag;


	void Start()
    {
		FillBulletPool();
    }

	void FillBulletPool()
    {
		if(WeaponData.Ammo <= 0)
			Debug.LogError("Clip size must be positive!");
        else
        {
			for(int i = 0; i < WeaponData.Ammo * 2; i++)
            {
				GameObject newBullet = Instantiate(BulletPrefab, BulletsContainer.position, BulletPrefab.transform.rotation, BulletsContainer);
				newBullet.GetComponent<Bullet>().Weapon = this;
				bulletPool.Enqueue(newBullet);
            }
        }
    }

	public void ReturnBulletToPool(GameObject bullet)
    {
		bulletPool.Enqueue(bullet);
		bullet.transform.position = BulletsContainer.position;
		bullet.transform.SetParent(BulletsContainer);
    }

	public void Fire(Vector3 direction) 
	{
		if (Time.time - lastShotFlag >= WeaponData.FireInterval)
		{
			GameObject bullet;
			try
			{
				bullet = bulletPool.Dequeue();
            }
			catch (System.InvalidOperationException)
            {
				Debug.LogWarning("Pool out of elements. Instantiating more bullets");
				FillBulletPool();
				bullet = bulletPool.Dequeue();
			}
			bullet.GetComponent<Bullet>().FireBullet(direction);
			lastShotFlag = Time.time;
		}
	}
}
