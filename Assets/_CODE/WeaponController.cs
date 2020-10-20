using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour 
{
	public Weapon currentWeapon;

	public void Shoot(Vector3 direction)
    {
		currentWeapon.Fire(direction);
    }
	
}
