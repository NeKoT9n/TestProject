using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI.Windows
{
    public enum WindowId
    {
        Menu,
        DailyBonus,
        Settings,
        levels,
        Shop
    }

    public class WindowController : IWindowController, IInitializable
    {
        private Dictionary<WindowId, IWindow> _windows;
        private IWindow _currentWindow;
        public void Initialize()
        {
            _windows = new();
        }

        public void OpenWindow(WindowId id)
        {
            if(_windows.TryGetValue(id, out IWindow window))
            {
                _currentWindow?.Close();
                window.Open();
                _currentWindow = window;
            }
        }

        public void CloseWindow(WindowId id) 
        {
            if (_windows.TryGetValue(id, out IWindow window))
            {
                window.Close();
            }
        }


        public void AddWindow(IWindow window)
        {
            if (_windows.ContainsKey(window.WindowId))
            {
                throw new System.ArgumentException("Window is exists");
            }

            _windows.Add(window.WindowId, window);

        }



    }
}