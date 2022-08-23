using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ST.Managers
{
    [RequireComponent(typeof(Util.Persistent))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameObject _masterSliderContainer;
        [SerializeField] private GameObject _musicSliderContainer;
        [SerializeField] private GameObject _soundEffectSliderContainer;
    }
}