using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace ST
{
    public class infoScreenScripts : MonoBehaviour
    {
        public static GameObject infoScreenTemplate;
        public void Play()
        {
            infoScreenTemplate = GameObject.Find("info screen template(Clone)");
            infoScreenTemplate.SetActive(false);
            
            junkMailScripts.game.SetActive(true);
            if (junkMailScripts.HasInfoScreenBeenDisplayed)
            {
                SceneManager.LoadScene("junkMailGame");
                junkMailScripts.HasInfoScreenBeenDisplayed = true;
            }
        }
        public void Quit()//poistu-nappi palaa toimisto n‰kym‰‰n
        {
            SceneManager.LoadScene("office");
        }
    }
}
