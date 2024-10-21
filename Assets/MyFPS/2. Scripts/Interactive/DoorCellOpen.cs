using UnityEngine;

namespace MyFPS
{
    // 문의 개폐를 전담하는 클래스
    public class DoorCellOpen : Interactive
    {
        // 필드
        #region Variables
        // Action: 문 열기
        private Animator animator;
        public AudioSource audioSource;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            action = "Open the Door";
            animator = GetComponentInParent<Animator>();
        }
        #endregion

        // 메서드
        #region Methods
        protected override void DoAction()
        {
            animator.SetBool("isOpen", true);
            audioSource.Play();
        }
        #endregion
    }
}