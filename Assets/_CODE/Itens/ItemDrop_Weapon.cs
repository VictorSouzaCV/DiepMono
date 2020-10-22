using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDrop_Weapon : ItemDrop
{
    public int WeaponID;
    public override void Collect(Character character)
    {
        character.WeaponController.UnlockWeapon(WeaponID);
        character.WeaponController.ReloadWeapons(WeaponID);
        base.Collect(character);
    }
}
