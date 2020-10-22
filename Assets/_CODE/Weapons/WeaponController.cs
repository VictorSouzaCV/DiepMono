using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour 
{
	List<Weapon> Weapons = new List<Weapon>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            Weapon equippedWeapon = child.GetComponent<Weapon>();
            if (equippedWeapon != null)
                Weapons.Add(equippedWeapon);
        }
    }

	public void Shoot(Vector3 direction)
    {
        foreach(Weapon w in Weapons)
        {
            if(w.gameObject.activeSelf)
		        w.Fire(direction);
        }
    }

	public void ReloadWeapons()
    {
        foreach (Weapon w in Weapons)
        {
            w.Reload();
        }
    }

    public void ReloadWeapons(int weaponID)
    {
        Weapons[weaponID].Reload();
    }

    public void UnlockWeapon(int weaponID)
    {
        foreach(Weapon w in Weapons)
        {
            if (w.WeaponData.Id == weaponID)
            {
                w.gameObject.SetActive(true);
            }
        }
    }


}
