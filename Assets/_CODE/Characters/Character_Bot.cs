using DiepMono.Data;
using DiepMono.Managers;
using System.Collections;
using UnityEngine;

namespace DiepMono.Characters
{
    public class Character_Bot : Character
    {
        EnemyCharacterData EnemyData;
        enum BotState
        {
            WANDER,
            PURSUIT
        }

        BotState state;

        float timeFlag;
        Vector3 ghostTarget;
        public LayerMask layerMask;

        public override void Awake()
        {
            base.Awake();
            EnemyData = (EnemyCharacterData)CharData;
        }

        void Start()
        {
            state = BotState.WANDER;
            timeFlag = Time.time;
            NewWanderTarget();
        }

        public override void Die()
        {
            ScoreManager.Instance.GainScore(20);
            gameObject.SetActive(false);
        }

        public override void ExecuteInput()
        {
            DoState();
        }

        void DoState()
        {
            switch (state)
            {
                case BotState.PURSUIT:
                    Pursuit();
                    Aim();
                    Shoot();
                    CheckPlayerCover();
                    break;
                case BotState.WANDER:
                    Wander();
                    SearchPlayer();
                    break;
            }
        }

        void ChangeState(BotState newState)
        {
            state = newState;
        }

        #region ATTACK
        void Pursuit()
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, CharData.Speed * Time.deltaTime);
        }

        public override void Aim()
        {
            AimDirection = GameManager.Instance.Player.transform.position - transform.position;
            transform.forward = AimDirection;
        }

        void CheckPlayerCover()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, AimDirection, out hit, Mathf.Infinity, layerMask))
            {
                if (!hit.transform.CompareTag("Player"))
                    ChangeState(BotState.WANDER);
            }
        }
        #endregion

        #region WANDER
        void Wander()
        {
            if (Time.time - timeFlag >= EnemyData.TimeChange)
            {
                if (!IsFacingWall())
                    NewWanderTarget();
                else
                    NewWanderTarget(180f);
                timeFlag = Time.time;
            }
            Vector3 vel = Vector3.Normalize(transform.forward);
            Vector3 desiredVel = Vector3.Normalize(ghostTarget - transform.position) * CharData.Speed / 2f;
            Vector3 steer = desiredVel - vel;
            // steer = Vector3.ClampMagnitude(steer, maxForce);
            vel = Vector3.ClampMagnitude(vel + steer, CharData.Speed);

            float distance = Vector3.Magnitude(ghostTarget - transform.position);

            if (distance <= EnemyData.MinDist)
                vel *= (distance - EnemyData.safeDist) / EnemyData.MinDist;

            transform.position += vel * Time.deltaTime;
            transform.LookAt(ghostTarget);
        }


        void NewWanderTarget()
        {
            float angle = UnityEngine.Random.Range(-EnemyData.Teta / 2, EnemyData.Teta / 2);
            angle *= Mathf.Deg2Rad;
            ghostTarget = this.transform.forward.normalized;
            Vector3 newPos = new Vector3(ghostTarget.x * Mathf.Cos(angle) - ghostTarget.z * Mathf.Sin(angle),
                                        0,
                                        ghostTarget.x * Mathf.Sin(angle) + ghostTarget.z * Mathf.Cos(angle));

            ghostTarget = new Vector3(newPos.x * EnemyData.Distance, 0, newPos.z * EnemyData.Distance);
        }

        void NewWanderTarget(float angle)
        {
            angle *= Mathf.Deg2Rad;
            ghostTarget = this.transform.forward.normalized;
            Vector3 newPos = new Vector3(ghostTarget.x * Mathf.Cos(angle) - ghostTarget.z * Mathf.Sin(angle),
                                        0,
                                        ghostTarget.x * Mathf.Sin(angle) + ghostTarget.z * Mathf.Cos(angle));

            ghostTarget = new Vector3(newPos.x * EnemyData.Distance, 0, newPos.z * EnemyData.Distance);
        }

        void TurnAround()
        {
            NewWanderTarget(180f);
        }

        void SearchPlayer()
        {
            EyeSearchPlayer();
            SoundSearchPlayer();
        }

        bool IsFacingWall()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
            {
                if (hit.transform.CompareTag("Wall"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        void EyeSearchPlayer()
        {
            int layerMask = 1 << 14;
            layerMask = ~layerMask; //Don't collide with Enemy layer

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, EnemyData.EyeDetectDist, layerMask))
            {
                if (hit.transform.CompareTag("Player"))
                    ChangeState(BotState.PURSUIT);
            }
        }

        void SoundSearchPlayer()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, GameManager.Instance.Player.transform.position - transform.position, out hit, EnemyData.SoundDetectDist, layerMask))
            {
                if (hit.transform.CompareTag("Player"))
                    ChangeState(BotState.PURSUIT);
            }
        }
        #endregion

    } 
}
