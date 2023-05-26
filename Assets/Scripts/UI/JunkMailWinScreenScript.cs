using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ST
{
    public class JunkMailWinScreenScript : MonoBehaviour
    {
        GameObject winScreen;
        public void replay()
        {
            SceneManager.LoadScene("junkMailGame");
        }
        public void exit()//jos k‰ytt‰j‰ haluaa poistua niin n‰ytet‰‰n infoscreen uudelleen ja winScreen piilotetaan
        {
            infoScreenScripts.infoScreenTemplate.SetActive(true);
            winScreen = GameObject.Find("JunkMailWinScreen(Clone)");
            winScreen.SetActive(false);
            junkMailScripts.HasInfoScreenBeenDisplayed = true;
        }
    }
}
