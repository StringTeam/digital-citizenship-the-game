using System.Collections;
using System.Collections.Generic;
using ST.Managers;
using ST.Types;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ST.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class DynamicScrollContent : MonoBehaviour
    {
        private const string _saveDataKeyPrefix = "SAVE_";
        private const int _maxSaves = 9;
        private RectTransform _this;
        private GridLayoutGroup _layoutGroup;
        private SaveManager _saveManager;
        private GameManager _gameManager;
        private UnityEvent _onItemCountChanged;

        private void Awake()
        {
            _this = GetComponent<RectTransform>();
            _layoutGroup = GetComponent<GridLayoutGroup>();
            _saveManager = FindObjectOfType<SaveManager>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            _ = StartCoroutine(WaitToUpdate());
        }

        private IEnumerator WaitToUpdate()
        {
            yield return new WaitForEndOfFrame();
            UpdateContentWidth();
        }

        private int GetSaveDataCount()
        {
            // TODO: Get save count from registry.
            //for (int i = 0; i < length; i++)
            //{
            //    Get items from registry
            //}

            return 0;
        }

        public void UpdateContentWidth()
        {
            Button[] buttons = GetComponentsInChildren<Button>();

            if (buttons.Length > 3)
                _this.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _layoutGroup.preferredWidth);
            else
                _this.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);

            _layoutGroup.childAlignment = buttons.Length < 3 ? TextAnchor.MiddleCenter : TextAnchor.MiddleLeft;
        }
    }
}