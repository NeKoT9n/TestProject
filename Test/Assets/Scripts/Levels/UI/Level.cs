using Assets.Scripts.UI.Windows;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Levels.UI
{
    public class Level : MonoBehaviour, IInitializable
    {

        [SerializeField] private Button _levelButton;
        [SerializeField] private Image _blockImage;

        public bool IsOpen => _isOpen;
        public event Action<Level> Complited;

        private bool _isOpen = false;

        public void SetOpen(bool isOpen)
        {
            _isOpen = isOpen;
            _levelButton.interactable = isOpen;
            _blockImage.gameObject.SetActive(!isOpen);
        }

        public void Initialize()
        {
            _levelButton.onClick.AddListener(OnLevelButtonClick);
        }

        private void OnLevelButtonClick()
        {
            Complited?.Invoke(this);
        }
    }
}