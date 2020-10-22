using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Bullet", order = 1)]
public class BulletData : ScriptableObject 
{
    public float Damage; //Damage per hit
    public float Speed;
}
