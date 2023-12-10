using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Settings
{
    public class VolumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        public void SetMusicVolume(float volume)
        {
            _mixer.SetFloat("MusicVolume", GetMixerVolumeValue(volume));
        }

        public void SetSoundVolume(float volume)
        {
            _mixer.SetFloat("SoundsVolume", GetMixerVolumeValue(volume));
        }

        private float GetMixerVolumeValue(float value)
        {
            return Mathf.Lerp(-80f, 0f, value);
        }
    }
}