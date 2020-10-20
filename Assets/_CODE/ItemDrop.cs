using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
    {
		Collect();
    }

	public virtual void Collect() 
	{ 
		Destroy(gameObject); 
	}

	void DestroyItem()
    {
		Destroy(gameObject);
    }
}
