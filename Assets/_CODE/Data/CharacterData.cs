using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Char", order = 1)]
public class CharacterData : ScriptableObject
{
    public float MaxHealth;
    public float Speed;
}
