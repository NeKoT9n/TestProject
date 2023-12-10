using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.Windows
{
    public interface IWindowController 
    {
        public void OpenWindow(WindowId windowId);
        public void CloseWindow(WindowId windowId);
        public void AddWindow(IWindow window);
    }
}