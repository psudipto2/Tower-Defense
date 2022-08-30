using UnityEngine.UI;
using UnityEngine;
using Singleton;

namespace Common
{
    public class PopUpController : MonoGenericSingleton<PopUpController>
    {
        [SerializeField] private GameObject winPopUp;
        [SerializeField] private GameObject losePopUp;
        [SerializeField] private GameObject pausePopUp;
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private Button resumeButton;

        private GameObject activePopUp;

        private void Start()
        {
            resumeButton.onClick.AddListener(ResumeButton);
            if (!uiCanvas.activeInHierarchy)
            {
                uiCanvas.SetActive(true);
            }
        }

        private void Update()
        {
            ActivePausePopUp();
        }

        private void ActivePausePopUp()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    pausePopUp.SetActive(true);
                    activePopUp = pausePopUp;
                }
            }
        }

        public void DisplayWinPopUp()
        {
            winPopUp.SetActive(true);
            uiCanvas.SetActive(false);
            activePopUp = winPopUp;
        }

        public void DisplayLosePopUp()
        {
            losePopUp.SetActive(true);
            uiCanvas.SetActive(false);
            activePopUp = losePopUp;
        }

        public void CloseActivePopUp()
        {
            if (activePopUp != null)
            {
                activePopUp.SetActive(false);
            }
        }

        private void ResumeButton()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                CloseActivePopUp();
            }
        }
    }
}
