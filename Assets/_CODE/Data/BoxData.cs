using System.Collections.Generic;
using UnityEngine;

namespace DiepMono.Data
{
    [CreateAssetMenu(fileName = "Box", menuName = "DATA/Box")]
    public class BoxData : ScriptableObject
    {
        public float MaxHealth;
        public int Score = 10;
        public List<GameObject> DropPool = new List<GameObject>();
    } 
}
