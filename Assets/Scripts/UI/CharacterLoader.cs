using UnityEngine;
using UnityEngine.UI;

namespace ST.UI
{
    public class CharacterLoader : MonoBehaviour
    {
        [SerializeField] private PopupContent _popupContent;
        private Button _button;
        private PopupManager _popup;

        private void Awake()
        {
            _button = GetComponentInParent<Button>();
            _popup = FindObjectOfType<PopupManager>();
        }

        private void Start()
        {
            _button.onClick.AddListener(delegate
            {
                _popup.ShowPopup(
                    _popupContent.OnLeftButton,
                    _popupContent.LBtnTxt,
                    _popupContent.OnMiddleButton,
                    _popupContent.MBtnTxt,
                    _popupContent.OnRightButton,
                    _popupContent.RBtnTxt,
                    _popupContent.Title,
                    _popupContent.Info);
            });

            //private void ShowPopup()
            //{
            //    // TODO: Show popup when clicking on a character select button.
            //    // Make a popup manager.
            //}

            // TODO: Load character preferences from SaveData.
        }
    }
}