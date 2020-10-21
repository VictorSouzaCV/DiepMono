using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Character : MonoBehaviour,IDamageable
{
    public CharacterData CharData;
	[HideInInspector] public Vector3 AimDirection;
    [HideInInspector] public Vector3 MoveDirection;
    public WeaponController WeaponController;

    Damageable damageComponent;
    public Damageable DamageComponent
    {
        get
        {
            if (damageComponent == null)
                damageComponent = new Damageable(CharData.MaxHealth);
            return damageComponent;
        }
    }

    void Awake()
    {
        damageComponent = new Damageable(CharData.MaxHealth);
    }

    void Update()
    {
        ExecuteInput();
    }

    public virtual void ExecuteInput() { }

    public virtual void Aim() { }
	public virtual void Shoot() 
    {
        WeaponController.Shoot(AimDirection);
    }
	public virtual void Move() { }
    public void TakeDamage(float damage)
    {
        damageComponent.Damage(damage);
    }    

    public Damageable GetDamageComponent()
    {
        return DamageComponent;
    }
}
