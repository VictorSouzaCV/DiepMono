using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable
{
    [HideInInspector] public UnityEvent OnDamageTaken = new UnityEvent();
    [HideInInspector] public UnityEvent OnDeath = new UnityEvent(); //called when Life <= 0

    public float Life;

    public Damageable(float maxLife)
    {
        Life = maxLife;
    }

	public void Damage(float damage)
    {
        Life -= damage;
        OnDamageTaken.Invoke();
        if (Life <= 0)
            OnDeath.Invoke();
    }
}
