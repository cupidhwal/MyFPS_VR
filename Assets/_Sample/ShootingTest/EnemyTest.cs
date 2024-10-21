using MyFPS;
using UnityEngine;

namespace MySample
{
    public class EnemyTest : MonoBehaviour, IDamagable
    {
        #region Variables
        [SerializeField] private float maxHealth = 20;
        [SerializeField] private float currentHealth;

        private bool isDeath = false;
        #endregion


        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"현재 체력: {currentHealth}");

            // 대미지 효과

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        public void Die()
        {
            isDeath = true;

            // 죽음 처리
            // 보상 - 경험치, 돈

            //효과
            Destroy(gameObject, 3f);
        }
    }
}