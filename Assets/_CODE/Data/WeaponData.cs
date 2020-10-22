using UnityEngine;

namespace DiepMono.Data
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "DATA/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public int Id;
        public int Ammo; //Max bullets quantity
        public float FireInterval;
    } 
}
