using TMPro;
using UnityEngine;

namespace MyFPS
{
    public abstract class Interactive : MonoBehaviour
    {
        // 필드
        #region Variables
        private float theDistance;

        // Action UI
        public GameObject extraCross;
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        protected string action = "Action";
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        #endregion

        // 메서드
        #region Methods
        private void SwitchActionUI(bool flag)
        {
            extraCross.SetActive(flag);
            actionUI.SetActive(flag);
        }

        protected abstract void DoAction();
        #endregion

        // 이벤트 메서드
        #region Event Methods
        // 마우스를 가져다 대면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            // 거리가 2이하 일때
            if (theDistance <= 2)
            {
                SwitchActionUI(true);
                actionText.text = action;

                if (Input.GetButtonDown("Action"))
                {
                    SwitchActionUI(false);

                    // 상호작용
                    DoAction();
                }
            }

            else
                SwitchActionUI(false);
        }

        // 마우스를 가져다 대면 액션 UI를 보여준다
        private void OnMouseExit()
        {
            SwitchActionUI(false);
        }
        #endregion
    }
}