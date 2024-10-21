using System.Collections;
using UnityEngine;

namespace MySample
{
    public class TorchLight : MonoBehaviour
    {
        public Transform torchLight;
        private Animator torchAnim;

        private int lightMode = 0;

        private void Start()
        {
            torchAnim = torchLight.GetComponent<Animator>();

            //1초에 한 번씩 애니메이션 랜덤 실행
            InvokeRepeating("FlameAnim", 1, 1);
        }

        void Update()
        {
            //1초에 한 번씩 애니메이션 랜덤 실행
            /*if (lightMode == 0)
                StartCoroutine(FlameAnimation());*/
        }

        IEnumerator FlameAnimation()
        {
            lightMode = Random.Range(1, 4);

            torchAnim.SetInteger("LightMode", lightMode);

            yield return new WaitForSeconds(1);

            lightMode = 0;
        }

        //인보크를 쓸 경우
        void FlameAnim()
        {
            lightMode = Random.Range(1, 4);

            torchAnim.SetInteger("LightMode", lightMode);
        }
    }
}