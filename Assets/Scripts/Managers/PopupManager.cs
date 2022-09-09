using System;
using UnityEngine;
using UnityEngine.UI;

namespace ST.UI
{
    [Serializable]
    public class PopupContent
    {
        [SerializeField] private Button _leftButton, _middleButton, _rightButton;
        [SerializeField] private string _leftButtonText, _middleButtonText, _rightButtonText;
        [SerializeField] private Action _onLeftButton, _onMiddleButton, _onRightButton;
        [SerializeField] private string _title, _info;

        public Button LeftButton { get => _leftButton; set => _leftButton = value; }
        public Button MiddleButton { get => _middleButton; set => _middleButton = value; }
        public Button RightButton { get => _rightButton; set => _rightButton = value; }
        public string LBtnTxt { get => _leftButtonText; set => _leftButtonText = value; }
        public string MBtnTxt { get => _middleButtonText; set => _middleButtonText = value; }
        public string RBtnTxt { get => _rightButtonText; set => _rightButtonText = value; }
        public Action OnLeftButton { get => _onLeftButton; set => _onLeftButton = value; }
        public Action OnMiddleButton { get => _onMiddleButton; set => _onMiddleButton = value; }
        public Action OnRightButton { get => _onRightButton; set => _onRightButton = value; }
        public string Title { get => _title; set => _title = value; }
        public string Info { get => _info; set => _info = value; }
    }

    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private Canvas _popup;
        [SerializeField] private PopupContent _popupContent;

        public void ShowPopup(Action leftButtonAction, string leftButtonText = null, Action middleButtonAction = null, string middleButtonText = null, Action rightButtonAction = null, string rightButtonText = null, string title = null, string info = null)
        {
            _popup.enabled = true;
        }
    }
}