using System.Collections;
using UnityEngine;

namespace MyFPS
{
    // 플레이어의 중심 클래스
    public class Player : MonoBehaviour, IDamagable
    {
        // 필드
        #region Variables
        public SceneFader fader;

        [SerializeField] private float maxHealth = 20;
        [SerializeField] private float currentHealth;

        private bool isDeath = false;

        public GameObject damageFlash;
        public AudioSource damageSound1;
        public AudioSource damageSound2;
        public AudioSource damageSound3;
        #endregion

        // 속성
        #region Properties
        public bool IsDeath => isDeath;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start()
        {
            currentHealth = maxHealth;
        }
        #endregion

        // 메서드
        #region Methods
        public void TakeDamage(float damage)
        {
            if (currentHealth > 0 && !isDeath)
            {
                currentHealth -= damage;
                Debug.Log($"Remain Health: {currentHealth}");
            }

            StartCoroutine(DamageEffect());

            if (currentHealth == 0)
                Die();

            else return;
        }

        public void Die()
        {
            isDeath = true;

            Debug.Log("You Dead");

            fader.FadeTo("GameOver");
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);

            switch (randNumber)
            {
                case 1:
                    damageSound1.Play();
                    break;
                case 2:
                    damageSound2.Play();
                    break;
                case 3:
                    damageSound3.Play();
                    break;
            }


            yield return new WaitForSeconds(0.5f);

            damageFlash.SetActive(false);

            yield break;
        }
        #endregion
    }
}