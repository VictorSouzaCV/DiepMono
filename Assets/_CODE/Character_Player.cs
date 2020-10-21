using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Character_Player : Character 
{
    public Transform AimTarget;

    public override void Die()
    {
        gameObject.SetActive(false);
        GameManager.Instance.FinishGame();
    }

    public override void ExecuteInput()
    {
        Aim();
        Move();
        Shoot();
    }

    void OnCollisionEnter (Collision col)
    {
        IDamageable otherDamageable = col.collider.GetComponent<IDamageable>();
        if(col.collider.CompareTag("Box"))
        {
            TakeDamage(10f);
            otherDamageable.TakeDamage(10f);
        }
        if(col.collider.CompareTag("Enemy"))
        {
            TakeDamage(30f);
            otherDamageable.TakeDamage(20f);
        }
    }

    public override void Aim()
    {
        AimTarget.position = CameraManager.Instance.ScreenToWorldPoint(Input.mousePosition);
        AimDirection = new Vector3(AimTarget.position.x - transform.position.x, 0, AimTarget.position.z - transform.position.z).normalized;
        transform.forward = AimDirection;
    }

    public override void Move()
    {
        MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(MoveDirection * CharData.Speed * Time.deltaTime, Space.World);
    }

    public override void Shoot()
    {
        if (Input.GetMouseButton(0))
            base.Shoot();
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               