using UnityEngine;

namespace DiepMono.Data
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "DATA/Bullet")]
    public class BulletData : ScriptableObject
    {
        public float Damage; //Damage per hit
        public float Speed;
    } 
}
