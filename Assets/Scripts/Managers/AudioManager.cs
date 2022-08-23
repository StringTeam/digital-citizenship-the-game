using ST.Audio;
using UnityEngine;
using UnityEngine.Audio;

namespace ST.Managers
{
    [RequireComponent(typeof(Util.Persistent))]
    public class AudioManager : MonoBehaviour
    {
        [Header("Mixer")]
        [SerializeField] private AudioMixer _mixer;

        [Header("Music")]
        [SerializeField] private SoundEffect _startingMusic;

        [SerializeField] private AudioSource _musicAS;
        private AudioSource _audioSource;

        public AudioMixer Mixer { get => _mixer; set => _mixer = value; }
        public SoundEffect StartingMusic { get => _startingMusic; set => _startingMusic = value; }
        public AudioSource MusicAS { get => _musicAS; set => _musicAS = value; }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayMusicTrack(StartingMusic);
        }

        public void ChangeMixerGroupVolume(string group, float volume) => _ = Mixer.SetFloat(group, volume);

        public void PlayClipOnce(SoundEffect effect)
        {
            _audioSource.outputAudioMixerGroup = effect.Mixer;
            _audioSource.PlayOneShot(effect.GetClip(), effect.Volume);
        }

        public void PlayClipOnce(SoundEffect effect, GameObject source)
        {
            if (!source.TryGetComponent(out AudioSource SourceAS))
                SourceAS = source.AddComponent<AudioSource>();

            SourceAS.outputAudioMixerGroup = effect.Mixer;
            SourceAS.spatialBlend = effect.SpatialBlend;
            SourceAS.PlayOneShot(effect.GetClip(), effect.Volume);
        }

        public void PlayMusicTrack(SoundEffect track)
        {
            MusicAS.outputAudioMixerGroup = track.Mixer;
            MusicAS.clip = track.GetClip();
            MusicAS.volume = track.Volume;
            MusicAS.loop = true;
            MusicAS.Play();
        }
    }
}