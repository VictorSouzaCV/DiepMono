using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Character : MonoBehaviour 
{
	public Vector3 AimDirection;
    public Vector3 MoveDirection;
    public float MoveSpeed = 1f;
    public WeaponController WeaponController;


    public virtual void Aim() { }
	public virtual void Shoot() 
    {
        WeaponController.Shoot(AimDirection);
    }
	public virtual void Move() { }
}
