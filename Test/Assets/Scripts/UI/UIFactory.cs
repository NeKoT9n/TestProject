using Assets.Scripts.AssetManagment;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Windows
{
    public class UIFactory : IUIFactory
    {
        private IAssetProvider _assetProvider;
        private IWindowController _windowController;
      
        [Inject]
        public UIFactory(IAssetProvider provider, IWindowController windowController)
        {
            _assetProvider = provider;
            _windowController = windowController;
        }
        public IWindow CreateWindow(WindowId id, Transform parent)
        {
            IWindow window = _assetProvider.InstantiateWindow(id, parent).GetComponent<IWindow>();
            window.Initialize();
            _windowController.AddWindow(window);

            Initialize(window.GetInitializables());

            return window;
        }

        private void Initialize(IInitializable[] initializables)
        {
            foreach(IInitializable initializable in initializables)
            {
                initializable.Initialize();
            }
        }
    }
}