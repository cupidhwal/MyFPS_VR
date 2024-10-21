using UnityEngine;
using StarterAssets;

namespace MyFPS
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;

        private Player player;
        #endregion

        #region Life Cycle
        private void Start()
        {
            player = FindAnyObjectByType<Player>();
            //player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SwitchPause();
        }
        #endregion

        #region Methods
        private void SwitchPause()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
                player.GetComponent<FirstPersonController>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0;
            }

            else
            {
                player.GetComponent<FirstPersonController>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1;
            }
        }

        public void Continue()
        {
            SwitchPause();
        }

        public void Menu()
        {
            Time.timeScale = 1;
            Debug.Log("Go to Menu!");
        }
        #endregion
    }
}