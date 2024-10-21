using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class DrawArmoryUI : MonoBehaviour
    {
        public TextMeshProUGUI armoryCount;

        void Update()
        {
            CurrentArmory();
        }

        void CurrentArmory()
        {
            armoryCount.text = PlayerStats.Instance.ArmoryCount.ToString();
        }
    }
}