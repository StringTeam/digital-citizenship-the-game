using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ST.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title, _message;
        [SerializeField] private Button _leftButton, _middleButton, _rightButton;
        private readonly string _defaultRightButtonText = "Close";

        public static void Show(string titleText, string messageText, UnityAction onLeftButtonClick, string leftButtonText, UnityAction onMiddleButtonClick = null, string middleButtonText = null, UnityAction onRightButtonClick = null, string rightButtonText = null)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/Popup"));
            Popup popup = go.GetComponent<Popup>();
            popup.Init(titleText, messageText, onLeftButtonClick, leftButtonText, onMiddleButtonClick, middleButtonText, onRightButtonClick, rightButtonText);
        }

        private void Init(string titleText, string messageText, UnityAction onLeftButtonClick, string leftButtonText, UnityAction onMiddleButtonClick, string middleButtonText, UnityAction onRightButtonClick, string rightButtonText)
        {
            _title.text = titleText;
            _message.text = messageText;
            _leftButton.GetComponentInChildren<TextMeshProUGUI>().text = leftButtonText;
            _leftButton.onClick.AddListener(onLeftButtonClick);

            _middleButton.enabled = false;
            if (onMiddleButtonClick != null && middleButtonText != null)
            {
                _middleButton.enabled = true;
                _middleButton.GetComponentInChildren<TextMeshProUGUI>().text = middleButtonText;
                _middleButton.onClick.AddListener(onMiddleButtonClick);
            }

            if (onRightButtonClick == null && rightButtonText == null)
            {
                rightButtonText = _defaultRightButtonText;
                onRightButtonClick = delegate { Destroy(gameObject); };
            }

            _rightButton.GetComponentInChildren<TextMeshProUGUI>().text = rightButtonText;
            _rightButton.onClick.AddListener(onRightButtonClick);
        }
    }
}