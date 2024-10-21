using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFPS
{
    // 로봇 상태
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }

    public class RobotControler : MonoBehaviour, IDamagable
    {
        #region Variables
        // 복합 변수
        private RobotState currentState;    // 로봇 상태 (enum)
        private RobotState beforeState;

        // 컴포넌트
        public AudioSource bgm01;
        public AudioSource bgm02;
        private Animator animator;
        private List<Collider> colliders = new();

        [SerializeField]private float maxHealth = 20;
        [SerializeField]private float currentHealth;

        private bool isDeath = false;

        private float moveSpeed = 2f;
        public Player player;

        // 타겟 레이어를 저장하는 리스트
        private List<LayerMask> layerMasks;

        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDamage = 5f;
        #endregion

        #region Life Cycle
        private void Start()
        {
            // 컴포넌트 초기화
            animator = GetComponentInChildren<Animator>();
            
            Collider[] colArray = GetComponentsInChildren<Collider>();
            foreach (Collider col in colArray)
            {
                colliders.Add(col);
            }

            currentHealth = maxHealth;
            SetState(RobotState.R_Idle);

            // 리스트 초기화
            layerMasks = new List<LayerMask>
            {
                LayerMask.GetMask("Player")
            };
        }

        private void Update()
        {
            // 로봇 상태 구현
            switch(currentState)
            {
                case RobotState.R_Idle:
                    break;

                case RobotState.R_Walk:     // 플레이어를 향해 걷기
                    AttackRangeCheck();
                    GoTotarget();
                    break;
                
                case RobotState.R_Attack:
                    AttackRangeCheck();
                    break;
                
                case RobotState.R_Death:
                    break;
            }
        }

        // 로봇의 상태 변경
        private void SetState(RobotState newState)
        {
            // 현재 상태 체크
            if (currentState == newState) return;

            // 이전 상태 저장
            beforeState = currentState;

            // 상태 변경
            currentState = newState;

            animator.SetInteger("RobotState", (int)newState);
        }

        private void GoTotarget()
        {
            // 전진
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);

            // 방향
            Vector3 targetDirection = player.transform.position - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = targetRotation;
        }

        private void AttackRangeCheck()
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance < attackRange - 0.1f)
                SetState(RobotState.R_Attack);

            else
                SetState(RobotState.R_Walk);
        }

        private void Attack()
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance < attackRange)
                player.TakeDamage(attackDamage);
        }

        /*private void AttackTimer()
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance > attackRange)
                SetState(RobotState.R_Idle);

            if (countDown < 0)
            {
                countDown = attackRate;

                player.TakeDamage(attackDamage);

                if (player.IsDeath)
                {
                    SetState(RobotState.R_Idle);
                }
            }

            else
                countDown -= Time.deltaTime;
        }*/

        public void TakeDamage(float damage)
        {
            if (currentHealth > 0 && !isDeath)
            {
                currentHealth -= damage;
                Debug.Log($"Remain Health: {currentHealth}");
            }

            if (currentHealth == 0)
                Die();

            else return;
        }

        public void Die()
        {
            isDeath = true;

            Debug.Log("Robot is Dead!");
            SetState(RobotState.R_Death);

            // 배경음 원상복구
            bgm02.Stop();
            bgm01.Play();

            foreach (Collider col in colliders)
            {
                colliders.Remove(col);
                Destroy(col);
            }
        }
        #endregion

        #region Event Methods
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("목표 포착");
                // 타겟 활성화
                SetState(RobotState.R_Walk);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("목표 상실");
                // 타겟 비활성화
                SetState(RobotState.R_Idle);
            }
        }
        #endregion
    }
}