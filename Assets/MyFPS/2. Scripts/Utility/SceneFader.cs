using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    // 장면 전환 시 페이드인/아웃 효과를 주는 클래스
    public class SceneFader : MonoBehaviour
    {
        // 필드
        #region Variables
        //Fader 이미지
        public Image image;
        public AnimationCurve curve;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start()
        {
            image.color = new Color(0f, 0f, 0f, 1f);
        }
        #endregion

        // 메서드
        #region Methods
        public void FadeFrom(float delay = 0f)
        {
            StartCoroutine(FadeIn(delay));
        }

        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }
        #endregion

        // 기타 유틸리티
        #region Utilities
        IEnumerator FadeIn(float delay)
        {
            if (delay > 0)
                yield return new WaitForSeconds(delay);

            //1초 동안 image a1 -> a0

            float t = 1;

            while (t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }
        }

        IEnumerator FadeOut(string sceneName)
        {
            //1초 동안 image a0 -> a1

            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }

            //다음 씬 로드
            SceneManager.LoadScene(sceneName);
        }
        #endregion
    }
}