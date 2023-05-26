using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

namespace ST
{

    public class CharacterCreation : MonoBehaviour
    {
        public TMP_InputField InputText;
        string PlayerName = "";
        int setColors;
        public void MainMenu()
        {
            SceneManager.LoadScene("menu");
        }
        public void CreateCharacter()
        {
            if (PlayerPrefs.GetInt("setColors") == 1 && PlayerName.Length > 0)
            {
                PlayerName = InputText.text;
                PlayerPrefs.SetString("PlayerName", PlayerName);
                SceneManager.LoadScene("Office");
            }
        }

        public void SaveName()
        {
            PlayerName = InputText.text;
            PlayerPrefs.SetString("PlayerName", PlayerName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
