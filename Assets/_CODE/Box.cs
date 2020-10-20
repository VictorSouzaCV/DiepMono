using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable {

	public BoxData BoxData;
    Damageable damageComponent;

	void Start()
    {
        damageComponent = new Damageable(BoxData.MaxHealth);
        damageComponent.OnDeath.AddListener(Break);
    }

    public void TakeDamage(float damage)
    {
        damageComponent.Damage(damage);
    }

    public void Break()
    {
        Debug.Log("Box broke!");
        gameObject.SetActive(false);
    }
}
