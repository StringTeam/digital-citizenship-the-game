using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ST.UI
{
    public class SliderValueText : MonoBehaviour
    {
        [SerializeField, Tooltip("Default: '%'")] private string _suffix = "%";
        private TextMeshProUGUI _sliderValue;
        private Slider _slider;

        private void Awake()
        {
            _sliderValue = GetComponent<TextMeshProUGUI>();
            _slider = transform.parent.gameObject.GetComponentInChildren<Slider>();
        }

        private void Start()
        {
            _slider.onValueChanged.AddListener(delegate { UpdateSliderValue(); });
            UpdateSliderValue();
        }

        private void UpdateSliderValue() => _sliderValue.text = $"{Mathf.RoundToInt(_slider.value)}{_suffix}";
    }
}