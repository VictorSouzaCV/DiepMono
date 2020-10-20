using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Box", order = 1)]
public class BoxData : ScriptableObject 
{
    public float MaxHealth;
    public List<GameObject> DropPool = new List<GameObject>();
}
