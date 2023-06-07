using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Siirt‰‰ peli skeneen
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Heitt‰‰ logiin 
    public void QuitGame()
    {
        Debug.Log("Quit");
    }

}
