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

        public string ParameterName { get => _parameterName; set => _parameterName = value; }
        public Slider Slider { get => _slider; set => _slider = value; }

        public VolumeSlider(string parameterName, Slider slider)
        {
            ParameterName = parameterName;
            Slider = slider;
        }
    }

    [RequireComponent(typeof(Persistent))]
    public class SettingsManager : MonoBehaviour
    {
        private AudioManager _audioManager;
        [SerializeField] private VolumeSlider[] _volumeSliders;
        [SerializeField] private TMP_Dropdown _resolutionDropdown;
        [SerializeField] private TMP_Dropdown _screenModeDropdown;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void Start()
        {
            InitializeResolutionDropdown();
        }

        private void InitializeResolutionDropdown()
        {
            _resolutionDropdown.value = (int)Screen.fullScreenMode;

            List<string> res = new();
            Resolution[] resolutions = Screen.resolutions;
            int value = 0;
            int num = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                Resolution resolution = resolutions[i];
                res.Add(string.Format("{0} x {1} @{2}Hz", resolution.width, resolution.height, resolution.refreshRate));

                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height &&
                    resolution.refreshRate == Screen.currentResolution.refreshRate)
                {
                    value = num;
                }

                num++;
            }

            _resolutionDropdown.ClearOptions();
            _resolutionDropdown.AddOptions(res);
            _resolutionDropdown.value = value;
            _resolutionDropdown.RefreshShownValue();
        }

        public void ChangeResolution(int index)
        {
            Resolution res = Screen.resolutions[index];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
        }

        public void ChangeVolume(int index) => _audioManager.ChangeMixerGroupVolume(_volumeSliders[index].ParameterName, _volumeSliders[index].Slider.value);
    }
}