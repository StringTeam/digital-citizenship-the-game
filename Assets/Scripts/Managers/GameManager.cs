using UnityEditor;
using UnityEngine;

namespace ST.Managers
{
    public class GameManager : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            SavePrefs();
            EditorApplication.isPlaying = false;
#endif
        }

        public void SavePrefs()
        {
            PlayerPrefs.Save();
#if UNITY_EDITOR
            Debug.Log("PlayerPrefs were saved.");
#endif
        }

        public bool HasKey(string key) => PlayerPrefs.HasKey(key);

        public string GetPref(string key) => PlayerPrefs.GetString(key);

        public void DelPref(string key) => PlayerPrefs.DeleteKey(key);

        public void SetPref(string key, string value) => PlayerPrefs.SetString(key, value);
    }
}