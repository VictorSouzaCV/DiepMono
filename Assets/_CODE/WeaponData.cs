using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Weapon", order = 1)]
public class WeaponData : ScriptableObject 
{
    public int Id;
    public int Ammo; //Max bullets quantity
    public float FireInterval; 
}
