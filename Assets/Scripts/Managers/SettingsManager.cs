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

        public VolumeSlider(string parameterName, Slider slider)
        {
            ParameterName = parameterName;
            Slider = slider;
            DefaultVolume = 50.0f;
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
            for (int i = 0; i < _volumeSliders.Length; i++)
            {
                VolumeSlider data = _volumeSliders[i];
                data.Slider.value = _gameManager.HasKey(data.ParameterName) ? float.Parse(_gameManager.GetPref(data.ParameterName)) : data.DefaultVolume;
                ChangeVolume(i);
            }
        }

        public void ChangeResolution(int index)
        {
            // TODO: Resolution not changing.
            Resolution res = Screen.resolutions[index];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
#if UNITY_EDITOR
            Debug.Log($"Resolution is <b>{res.width} x {res.height} @{res.refreshRate}Hz</b>");
#endif
        }

        public void ChangeScreenMode(int index)
        {
            // TODO: Screen mode not changing.
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
#if UNITY_EDITOR
            Debug.Log($"ScreenMode is <b>{(int)Screen.fullScreenMode}</b>");
#endif
        }

        public void ChangeVolume(int index) => _audioManager.ChangeMixerGroupVolume(_volumeSliders[index].ParameterName, _volumeSliders[index].Slider.value);
    }
}