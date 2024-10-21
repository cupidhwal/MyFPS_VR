using UnityEngine;

namespace MyFPS
{
    public class ArmoryBox : Interactive
    {
        #region Variables
        [SerializeField] private int giveArmory = 7;

        // Action
        public GameObject arrow;
        #endregion

        #region Life Cycle
        void Start()
        {
            action = "Pickup your Armory";
        }
        #endregion

        #region Methods
        protected override void DoAction()
        {
            arrow.SetActive(false);

            PlayerStats.Instance.AddArmory(giveArmory);

            Destroy(gameObject);
        }
        #endregion
    }
}