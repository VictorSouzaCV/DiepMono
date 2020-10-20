using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Character_Player : Character 
{
    public Transform AimTarget;
    void Update() 
    {
        Aim();
        Move();
        Shoot();
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
        transform.Translate(MoveDirection * MoveSpeed * Time.deltaTime, Space.World);
    }

    public override void Shoot()
    {
        if (Input.GetMouseButton(0))
            base.Shoot();
    }
}
