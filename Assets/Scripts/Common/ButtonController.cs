using UnityEngine.SceneManagement;
using UnityEngine;

namespace Common
{
    public class ButtonController : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("Game Scene");
            PopUpController.Instance.CloseActivePopUp();
        }

        public void MainMenuButton()
        {
            SceneManager.LoadSceneAsync("Lobby Scene");
            PopUpController.Instance.CloseActivePopUp();
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}