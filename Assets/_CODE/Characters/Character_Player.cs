using DiepMono.Managers;
using DiepMono.Utils;
using UnityEngine;

namespace DiepMono.Characters
{
    public class Character_Player : Character
    {
        public Transform AimTarget;
        public Camera Camera;
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

        void OnCollisionEnter(Collision col)
        {
            IDamageable otherDamageable = col.collider.GetComponent<IDamageable>();
            if (col.collider.CompareTag("Box"))
            {
                TakeDamage(10f);
                otherDamageable.TakeDamage(10f);
            }
            if (col.collider.CompareTag("Enemy"))
            {
                TakeDamage(30f);
                if (otherDamageable != null)
                    otherDamageable.TakeDamage(20f);
            }
        }

        public override void Aim()
        {
            AimTarget.position = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.6f));
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
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          