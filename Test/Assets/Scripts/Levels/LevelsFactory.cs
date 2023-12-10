using Assets.Scripts.AssetManagment;
using Assets.Scripts.Data;
using Assets.Scripts.Levels.UI;
using Assets.Scripts.UI.Windows;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Levels
{
    public class LevelsFactory : ILevelsFactory
    {

        private IAssetProvider _assetProvider;
        private Level _levelUI;

        
        [Inject]
        public LevelsFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Level CreateLevel(Transform parent)
        {
            var level = _assetProvider.InstantiateLevel(parent).GetComponent<Level>();

            return level;
        }

    

    }
}