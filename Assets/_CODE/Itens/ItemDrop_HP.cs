using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop_HP : ItemDrop {
    public override void Collect(Character character)
    {
        character.DamageComponent.Heal();
        base.Collect(character);
    }
}
