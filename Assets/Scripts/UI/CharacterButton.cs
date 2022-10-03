using UnityEngine;
using UnityEngine.UI;

namespace ST.UI
{
    public class CharacterButton : MonoBehaviour
    {
        private readonly string _characterName = "Yrjö";

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Show);
        }

        //// TODO: This
        //private void GetInfo()
        //{
        //}

        private void Show()
        {
            Popup.Show(
                _characterName,
                $"What do you want to do with {_characterName}",
                Play,
                "Play",
                Delete,
                "Delete");
        }

        private void Play()
        {
#if UNITY_EDITOR
            Debug.LogFormat("Play() {0}", _characterName);
#endif
        }

        private void Delete()
        {
#if UNITY_EDITOR
            Debug.LogFormat("Delete() {0}", name);
#endif
        }
    }
}