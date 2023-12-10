using Assets.Scripts.UI.Windows;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _parent;
        [Inject] private UIFactory _uiFactory;
        [Inject] private WindowController _windowController;

        public override void InstallBindings()
        {
            CreateWindow(WindowId.Menu, true);
            CreateWindow(WindowId.DailyBonus);
            CreateWindow(WindowId.Settings);
            CreateWindow(WindowId.levels);
            CreateWindow(WindowId.Shop);
        }

        private void CreateWindow(WindowId id, bool isOpen = false)
        {
            _uiFactory.CreateWindow(id, _parent.transform);

            if (isOpen == true)
                _windowController.OpenWindow(id);
            else
                _windowController.CloseWindow(id);
        }

    }
}