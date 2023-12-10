using Assets.Scripts.UI.Windows;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Settings
{
    public class SliderSettings : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Slider _slider;

        public Action<float> OnValueChanged;

        private float _currentValue;

        public void Initialize()
        {
            _slider.onValueChanged.AddListener((value) => OnValueChanged?.Invoke(value));
        }

        public void SetValue(float value)
        {
            if(value < 0 && value > 1) 
            {
                throw new ArgumentOutOfRangeException("value");
            }

            _currentValue = value;
            _slider.SetValueWithoutNotify(_currentValue);
        }

        public void Dispose()
        {
            _slider.onValueChanged.RemoveAllListeners();
        }
    }
}