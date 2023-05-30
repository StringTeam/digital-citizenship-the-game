using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ST
{

    public class ButtonBehaviour : MonoBehaviour
    {

        public void LoadSCene(string scene_name)
        {
            SceneManager.LoadScene(scene_name);
        }

    public void ResetGameSettings()
    {
        GameSettings.Instance.ResetGameSettings();
    }
}
}
