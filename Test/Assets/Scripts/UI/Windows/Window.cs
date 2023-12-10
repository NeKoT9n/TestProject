using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Windows
{
    [System.Serializable]
    struct WindowToButton
    {
        public WindowId id;
        public Button button;
    }
    public class Window : MonoBehaviour, IWindow
    {
        [SerializeField] private List<WindowToButton> _windowToButton;
        [SerializeField] private WindowId _windowId;
        public WindowId WindowId => _windowId;

        private IWindowController _windowController;


        [Inject]
        private void Construct(IWindowController windowController)
        {
            _windowController = windowController;
        }

        public void Initialize()
        {
            foreach (var button in _windowToButton)
            {
                WindowId id = button.id;
                button.button.onClick.AddListener(() => _windowController.OpenWindow(id));
            }
        }


        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public IInitializable[] GetInitializables()
        {
            return GetComponentsInChildren<IInitializable>();
        }
    }
}