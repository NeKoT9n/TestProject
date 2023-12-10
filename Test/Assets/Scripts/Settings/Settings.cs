using Assets.Scripts.Data;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Settings
{
    public class Settings : MonoBehaviour, UI.Windows.IInitializable, IDisposable
    {
        [SerializeField] private SliderSettings _MusicSlider;
        [SerializeField] private SliderSettings _SoundsSlider;
        [SerializeField] private  VolumeSettings _volumeSettings;

        [Inject] private UserDataContainer _dataContainer;

        public void Initialize()
        {
            float music = _dataContainer.SettingsData.MusicVolume;
            float sounds = _dataContainer.SettingsData.SoundVolume;

            _MusicSlider.SetValue(music);
            _SoundsSlider.SetValue(sounds);
            _volumeSettings.SetMusicVolume(music);
            _volumeSettings.SetSoundVolume(sounds);

            _MusicSlider.OnValueChanged += UpdateMusicSettings;
            _SoundsSlider.OnValueChanged += UpdateSoundSettings;


        }

        public void Dispose()
        {
            _MusicSlider.OnValueChanged -= UpdateMusicSettings;
            _SoundsSlider.OnValueChanged -= UpdateSoundSettings;
        }


        private void UpdateMusicSettings(float value)
        {
            _dataContainer.SettingsData.MusicVolume = value;
            _volumeSettings.SetMusicVolume(value);
        }

        private void UpdateSoundSettings(float value)
        {
            _dataContainer.SettingsData.SoundVolume = value;
            _volumeSettings.SetSoundVolume(value);
        }
        
    }
}