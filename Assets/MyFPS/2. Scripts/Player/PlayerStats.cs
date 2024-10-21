using UnityEngine;
using MyDefence;

namespace MyFPS
{
    // 플레이어의 속성값을 관리하는 싱글톤 클래스
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        /*#region Singleton
        public static PlayerStats Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }
        #endregion*/

        #region Variables
        // 탄환 갯수
        private int armoryCount;
        #endregion

        #region Properties
        public int ArmoryCount
        {
            get { return armoryCount; }
            private set { armoryCount = value; }
        }
        #endregion

        #region Life Cycle
        private void Start()
        {
            // 속성 초기화
            ArmoryCount = 0;
        }
        #endregion

        #region Methods
        public void AddArmory(int amount)
        {
            ArmoryCount += amount;
        }

        public bool UseArmory(int amount)
        {
            if (ArmoryCount < amount)
            {
                Debug.Log("총알이 부족해.");
                return false;
            }

            ArmoryCount -= amount;
            return true;
        }
        #endregion
    }
}