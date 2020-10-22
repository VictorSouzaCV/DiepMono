using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop_Ammo : ItemDrop 
{
    public override void Collect(Character character)
    {
        character.WeaponController.ReloadWeapons();
        base.Collect(character);
    }
}
