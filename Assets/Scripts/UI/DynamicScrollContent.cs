using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ST.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class DynamicScrollContent : MonoBehaviour
    {
        private RectTransform _this;
        private GridLayoutGroup _layoutGroup;
        private UnityEvent _onItemCountChanged;

        private void Awake()
        {
            _this = GetComponent<RectTransform>();
            _layoutGroup = GetComponent<GridLayoutGroup>();
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

        //private SaveData GetSaveData() { }

        private int GetSaveDataCount()
        {
            // TODO: Get save count from registry.
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