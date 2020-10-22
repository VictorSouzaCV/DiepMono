using UnityEngine;

namespace DiepMono.Data
{
    [CreateAssetMenu(fileName = "EnemyCharacter", menuName = "DATA/EnemyCharacter")]
    public class EnemyCharacterData : CharacterData
    {
        [Header("Wander Behaviour")]
        public float Distance = 3;
        public float TimeChange = 1; //time to change ghost target
        public float Teta = 90; //angle variation	
        public float MinDist = 0.5f;
        public float safeDist = 0.1f;

        [Header("Attack Behaviour")]
        public float EyeDetectDist = 8f;
        public float SoundDetectDist = 3.5f;
    } 
}
