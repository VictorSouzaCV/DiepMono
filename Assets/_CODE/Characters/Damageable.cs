using UnityEngine;
using UnityEngine.Events;

public class Damageable
{
    [HideInInspector] public UnityEvent OnDamageTaken = new UnityEvent();
    [HideInInspector] public UnityEvent OnDeath = new UnityEvent(); //called when CurrentLife <= 0

    public float MaxLife;
    public float CurrentLife;

    public Damageable(float maxLife)
    {
        MaxLife = maxLife;
        CurrentLife = MaxLife;
    }

	public void Damage(float damage)
    {
        CurrentLife -= damage;
        OnDamageTaken.Invoke();
        if (CurrentLife <= 0)
            OnDeath.Invoke();
    }

    public void Heal()
    {
        CurrentLife = MaxLife;
        OnDamageTaken.Invoke();
    }
}
