using UnityEngine;

namespace MyFPS
{
    public class PickUpPistol : Interactive
    {
        // 필드
        #region Variables
        // Action
        public GameObject arrow;
        public GameObject realPistol;

        public GameObject armoryUI;
        public GameObject armoryBox;
        public GameObject enemyTrigger;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            action = "Pickup the Pistol";
        }
        #endregion

        // 메서드
        #region Methods
        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);

            armoryUI.SetActive(true);
            armoryBox.SetActive(true);
            enemyTrigger.SetActive(true);

            Destroy(gameObject);
        }
        #endregion
    }
}