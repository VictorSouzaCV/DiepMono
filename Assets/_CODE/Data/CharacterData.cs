using UnityEngine;

namespace DiepMono.Data
{
    [CreateAssetMenu(fileName = "Character", menuName = "DATA/Character")]
    public class CharacterData : ScriptableObject
    {
        public float MaxHealth;
        public float Speed;
    } 
}
