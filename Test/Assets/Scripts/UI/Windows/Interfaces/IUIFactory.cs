using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.Windows
{
    public interface IUIFactory
    {
        public IWindow CreateWindow(WindowId id, Transform parent);
    }


        
}