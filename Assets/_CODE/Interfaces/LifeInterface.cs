using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IDamageable))]
public class LifeInterface : MonoBehaviour {

	[SerializeField] Canvas lifeCanvas;
	[SerializeField] Image lifeBar;
	Damageable damageable;

	void Start () 
	{
		damageable = GetComponent<IDamageable>().GetDamageComponent();
		damageable.OnDamageTaken.AddListener(ReduceLife);
	}
	
	void ReduceLife () 
	{
		if (!lifeCanvas.enabled)
			lifeCanvas.enabled = true;
		lifeBar.fillAmount = damageable.CurrentLife / damageable.MaxLife;
	}
}
