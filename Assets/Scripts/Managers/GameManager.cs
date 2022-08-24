using ST.Util;
using UnityEditor;
using UnityEngine;

namespace ST.Managers
{
    [RequireComponent(typeof(Persistent))]
    public class GameManager : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

        public void SavePrefs() => PlayerPrefs.Save();

        public bool HasKey(string key) => PlayerPrefs.HasKey(key);

        public void SetPref(string key, string value) => PlayerPrefs.SetString(key, value);

        public string GetPref(string key) => PlayerPrefs.GetString(key);
    }
}