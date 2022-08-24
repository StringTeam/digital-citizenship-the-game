using System;
using System.Collections.Generic;
using ST.Util;
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

        public VolumeSlider(string parameterName, Slider slider, float defaultVolume)
        {
            ParameterName = parameterName;
            Slider = slider;
            DefaultVolume = defaultVolume;
        }
    }

    [RequireComponent(typeof(Persistent))]
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
            _screenModeDropdown.value = (int)Screen.fullScreenMode;
            InitializeResolutionDropdown();
            InitializeVolumeSliders();
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
        }

        private void InitializeVolumeSliders()
        {
            // TODO: If no key found set to default volume value.
            // TODO: Slider Value Text not updating.
            foreach (VolumeSlider data in _volumeSliders)
                data.Slider.value = _gameManager.HasKey(data.ParameterName) ? float.Parse(_gameManager.GetPref(data.ParameterName)) : data.DefaultVolume;
        }

        public void ChangeResolution(int index)
        {
            Resolution res = Screen.resolutions[index];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
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
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                    break;
            }
        }

        public void ChangeVolume(int index) => _audioManager.ChangeMixerGroupVolume(_volumeSliders[index].ParameterName, _volumeSliders[index].Slider.value);
    }
}