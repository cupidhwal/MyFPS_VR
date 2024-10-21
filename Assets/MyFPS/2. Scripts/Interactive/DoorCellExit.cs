using UnityEngine;

namespace MyFPS
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainScene02";

        private Animator animator;
        public AudioSource creakyDoor;
        public AudioSource bgm01;
        #endregion

        #region Life Cycle
        private void Start()
        {
            animator = GetComponentInParent<Animator>();
        }
        #endregion

        #region Methods
        // 상호작용을 실행하는 메서드
        protected override void DoAction()
        {
            //1. 문을 여는 애니메이션
            animator.SetBool("isOpen", true);
            
            //2. 문을 여는 사운드
            creakyDoor.Play();

            //3. 다음 씬으로 이동
            ChangeScene();
        }

        private void ChangeScene()
        {
            // 씬 마무리
            // 다음 씬으로 이동
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}