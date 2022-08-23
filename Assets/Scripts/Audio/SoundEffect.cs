using UnityEngine;
using UnityEngine.Audio;

namespace ST.Audio
{
    /// <summary>
    /// Add a sound effect to an game object.
    /// </summary>
    [System.Serializable]
    public class SoundEffect
    {
        [SerializeField, Range(0.0f, 1.0f)] private float _volume;
        [SerializeField, Range(0.0f, 1.0f)] private float _spatialBlend;
        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] private AudioClip[] _clips;

        public float Volume { get => _volume; set => _volume = value; }
        public float SpatialBlend { get => _spatialBlend; set => _spatialBlend = value; }
        public AudioMixerGroup Mixer { get => _mixer; set => _mixer = value; }
        public AudioClip[] Clips { get => _clips; set => _clips = value; }

        /// <returns>Random audio clip from an array.</returns>
        public AudioClip GetClip() => Clips.Length <= 0 ? null : Clips[Random.Range(0, Clips.Length)];
    }
}