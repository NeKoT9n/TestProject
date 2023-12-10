using Assets.Scripts.Levels.UI;
using Assets.Scripts.UI.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.AssetManagment
{
    public class ResourcesAssetProvider : IAssetProvider, UI.Windows.IInitializable
    {
        private const string WINDOWS_PATH = "UI/Windows";
        private const string LEVELS_PATH = "UI/Levels";

        private Dictionary<WindowId, Window> _windows;
        private List<Level> _levels;

        [Inject] private DiContainer _container;

        public void Initialize()
        {
            _windows = Resources
                .LoadAll<Window>(WINDOWS_PATH)
                .ToDictionary(x => x.WindowId, x => x);

            _levels = Resources
                .LoadAll<Level>(LEVELS_PATH)
                .ToList();


        }

        public Object InstantiateWindow(WindowId id, Transform parent)
        {
            if(_windows.ContainsKey(id) == false)
            {
                return null;
            }

            return _container.InstantiatePrefab(_windows[id], parent);
        }



        public Object InstantiateLevel(Transform parent)
        {
            if (_levels == null)
            {
                return null;
            }


            return _container.InstantiatePrefab(_levels[0], parent);
        }
    }
}