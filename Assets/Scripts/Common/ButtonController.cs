using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TowerMVC;
using UnityEngine;

namespace Common
{
    public class ButtonController : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadSceneAsync("Game Scene");
            //TowerService.Instance.CreateTowers();
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