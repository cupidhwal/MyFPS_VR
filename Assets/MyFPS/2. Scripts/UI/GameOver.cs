using UnityEngine;

namespace MyFPS
{
    public class GameOver : MonoBehaviour
    {
        // 필드
        #region Variables
        public SceneFader fader;
        [SerializeField]private string loadToRetry = "PlayScene";
        [SerializeField]private string loadToMenu = "PlayScene";
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            fader.FadeFrom(0);

            Cursor.lockState = CursorLockMode.Confined;
        }
        #endregion

        // 메서드
        #region Methods
        public void RetryButton()
        {
            fader.FadeTo(loadToRetry);
        }

        public void MenuButton()
        {
            fader.FadeTo(loadToMenu);
        }
        #endregion
    }
}