using System.Collections;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFPS
{
    public class AOpening : MonoBehaviour
    {
        // 필드
        #region Variables
        public GameObject player;
        public SceneFader fader;

        // 시나리오 시퀀스 관련 필드
        [SerializeField] private string sequence01 = "...Where am I?";
        [SerializeField] private string sequence02 = "I need get out of here";
        public TextMeshProUGUI sequenceText;

        public AudioSource sequenceAudio01;
        public AudioSource sequenceAudio02;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void Start ()
        {
            StartCoroutine(PlaySequence());
        }
        #endregion

        // 기타 유틸리티
        #region Utilities
        IEnumerator PlaySequence()
        {
            // 1. 플레이어 캐릭터 비활성화
            player.GetComponent<FirstPersonController>().enabled = false;

            // 2. 페이드인 연출 (1초 대기 후 페이드인 효과)
            fader.FadeFrom(4f);  // 2초 동안 페이드인 효과 진행

            // 3. 화면 하단에 시나리오 텍스트 출력 (3초)
            // "...Where am I?"
            sequenceText.gameObject.SetActive(true);
            sequenceText.text = sequence01;
            sequenceAudio01.Play();
            yield return new WaitForSeconds(3f);

            // "I need get out of here"
            sequenceText.text = sequence02;
            sequenceAudio02.Play();

            // 4. 3초 후 시나리오 텍스트 제거
            yield return new WaitForSeconds(3f);
            sequenceText.text = "";
            sequenceText.gameObject.SetActive(false);

            // 5. 플레이어 캐릭터 활성화
            player.GetComponent<FirstPersonController>().enabled = true;
        }
        #endregion
    }
}