using Assets.Scripts.Levels.UI;
using Assets.Scripts.UI.Windows;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AssetManagment
{
    public interface IAssetProvider 
    {
        public Object InstantiateWindow(WindowId id, Transform parent);
        public Object InstantiateLevel(Transform parent);
    }
}