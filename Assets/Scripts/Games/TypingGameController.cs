using System.Linq;
using TMPro;
using UnityEngine;

namespace ST.Games.TypingGame
{
    public class TypingGameController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _textContainer;
        [SerializeField] private string[] _content;
        private TextMeshProUGUI[] _textMeshes;
        private int _currentItem = 0;

        private void Awake()
        {
            _textMeshes = _textContainer.GetComponentsInChildren<TextMeshProUGUI>();
            _inputField.onValueChanged.AddListener(ValueChanged);
            _inputField.Select();
            _inputField.ActivateInputField();
        }

        private void Start()
        {
            _content = _content.Select(s => s.ToUpper()).ToArray();

            foreach (TextMeshProUGUI item in _textMeshes)
                item.text = _content[_currentItem];
        }

        private void UpdateSelectedItem(int amount = 1) => _currentItem += amount;

        private void ValueChanged(string arg)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                CheckValue(arg);
        }

        private void CheckValue(string arg)
        {
            string text = _content[_currentItem];

            if (arg == text)
            {
#if UNITY_EDITOR
                Debug.LogFormat("{0} == {1}", arg, text);
#endif
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogFormat("{0}, {1}", arg, text);
#endif
            }
        }
    }
}