using Assets.Scripts.Data;
using Assets.Scripts.UI.Windows;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Levels.UI
{
    public class ExitButton : MonoBehaviour, Scripts.UI.Windows.IInitializable
    {

        [SerializeField] private Button _exitButton;
        private ISaveLoadService _saveLoadService;

        [Inject]
        public void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        public void Initialize()
        {
            _exitButton.onClick.AddListener(Exit);
        }

        private void Exit()
        {
            _saveLoadService.Save();
            Application.Quit();
        }
    }
}