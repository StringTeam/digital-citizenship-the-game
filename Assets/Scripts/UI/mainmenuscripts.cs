using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ST
{
    public class mainmenuscripts : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
        }
        public void Settings()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/Managers.1"));
        }
        public void NewGame()
        {
            SceneManager.LoadScene("CharacterCreation");
        }
        public void LoadGame()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/LevelSelect"));
        }
        public void LoadMainMenu()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/mainmenu"));
        }
    }
}
