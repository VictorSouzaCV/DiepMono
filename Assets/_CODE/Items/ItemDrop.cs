using DiepMono.Characters;
using UnityEngine;

namespace DiepMono.Items
{
    public class ItemDrop : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Collect(other.GetComponent<Character>());
        }

        public virtual void Collect(Character character)
        {
            Destroy(gameObject);
        }
    } 
}
