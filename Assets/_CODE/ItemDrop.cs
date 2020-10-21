using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void DestroyItem()
    {
		Destroy(gameObject);
    }
}
