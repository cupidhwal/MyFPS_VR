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

            //1�ʿ� �� ���� �ִϸ��̼� ���� ����
            InvokeRepeating("FlameAnim", 1, 1);
        }

        void Update()
        {
            //1�ʿ� �� ���� �ִϸ��̼� ���� ����
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

        //�κ�ũ�� �� ���
        void FlameAnim()
        {
            lightMode = Random.Range(1, 4);

            torchAnim.SetInteger("LightMode", lightMode);
        }
    }
}