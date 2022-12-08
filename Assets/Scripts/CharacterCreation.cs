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
    //Script for the character Creation Scene
    public class CharacterCreation : MonoBehaviour
    {
        public TMP_InputField InputText;
        string PlayerName = "";
        int setColors;
        public void MainMenu()  //Method to load Main Menu Scene
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void CreateCharacter() //Method to Load the next scene, which is the Office Scene
        {
            if (PlayerPrefs.GetInt("setColors") == 1 && PlayerName.Length > 0) //Only lets the player load the next scene if they have set their name and colors
            {
                PlayerName = InputText.text;
                PlayerPrefs.SetString("PlayerName", PlayerName);
                SceneManager.LoadScene("Office");
            }
        }

        public void SaveName()  //Method for saving the players name from the input bar and saving it into playerprefs
        {
            PlayerName = InputText.text;
            PlayerPrefs.SetString("PlayerName", PlayerName);
        }

        public void QuitGame() //Method to Quit the game
        {
            Application.Quit();
        }

    }
}
