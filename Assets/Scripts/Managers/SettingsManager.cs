using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ST.Managers
{
    [Serializable]
    internal class VolumeSlider
    {
        [SerializeField, Tooltip("The name of the exposed parameter.")] private string _parameterName;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _defaultVolume;

        public string ParameterName { get => _parameterName; set => _parameterName = value; }
        public Slider Slider { get => _slider; set => _slider = value; }
        public float DefaultVolume { get => _defaultVolume; set => _defaultVolume = value; }

        public VolumeSlider(string parameterName, Slider slider)
        {
            ParameterName = parameterName;
            Slider = slider;
            DefaultVolume = 50.0f;
        }
    }

    public class SettingsManager : MonoBehaviour
    {
        private AudioManager _audioManager;
        private GameManager _gameManager;
        [SerializeField] private VolumeSlider[] _volumeSliders;
        [SerializeField] private TMP_Dropdown _resolutionDropdown;
        [SerializeField] private TMP_Dropdown _screenModeDropdown;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            InitializeScreenModeDropdown();
            InitializeResolutionDropdown();
            InitializeVolumeSliders();
        }

        private void InitializeScreenModeDropdown()
        {
            _screenModeDropdown.value = (int)Screen.fullScreenMode;
            _screenModeDropdown.onValueChanged.AddListener(delegate { ChangeScreenMode(_screenModeDropdown.value); });
        }

        private void InitializeResolutionDropdown()
        {
            _resolutionDropdown.value = (int)Screen.fullScreenMode;

            List<string> res = new();
            Resolution[] resolutions = Screen.resolutions;
            int currentResolution = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                Resolution resolution = resolutions[i];
                res.Add(string.Format("{0} x {1} @{2}Hz", resolution.width, resolution.height, resolution.refreshRate));

                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height &&
                    resolution.refreshRate == Screen.currentResolution.refreshRate)
                    currentResolution = i;
            }

            _resolutionDropdown.ClearOptions();
            _resolutionDropdown.AddOptions(res);
            _resolutionDropdown.value = currentResolution;
            _resolutionDropdown.RefreshShownValue();

            _resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        }

        private void InitializeVolumeSliders()
        {
            for (int i = 0; i < _volumeSliders.Length; i++)
            {
                VolumeSlider data = _volumeSliders[i];
                data.Slider.value = _gameManager.HasKey(data.ParameterName) ? float.Parse(_gameManager.GetPref(data.ParameterName)) : data.DefaultVolume;
#if UNITY_EDITOR
                // TODO: Make an audio slider automatically have ChangeVolume method.
                // NOTE: ChangeVolume cannot be added, because it needs an index of the slider, the following snippet doesn't work.
                // ERROR: IndexOutOfRangeException: Index was outside the bounds of the array.
                //data.Slider.onValueChanged.AddListener(delegate { ChangeVolume(i); });
#endif
                ChangeVolume(i);
            }
        }

        public void ChangeResolution(int index)
        {
            Resolution res = Screen.resolutions[index];
            Screen.SetResolution(res.width, res.height, false, res.refreshRate);
#if UNITY_EDITOR
            Debug.Log($"Resolution was set to <b>{res.width} x {res.height} @{res.refreshRate}Hz</b>");
#endif
        }

        public void ChangeScreenMode(int index)
        {
            switch (index)
            {
                case 0:
                    Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                    break;

                case 1:
                    Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                    break;

                case 2:
                    Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                    break;

                case 3:
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                    break;
            }
        }

        public void ChangeVolume(int index)
        {
            VolumeSlider volumeSlider = _volumeSliders[index];
            float groupVolume = Mathf.Clamp(volumeSlider.Slider.value, 0.0001f, volumeSlider.Slider.maxValue);
            _audioManager.ChangeMixerGroupVolume(volumeSlider.ParameterName, groupVolume);
        }
    }
}