using Assets.Scripts.UI.Windows;
using UnityEngine;

public interface IWindow : IInitializable
{
    public WindowId WindowId { get; }

    public void Open();
    public void Close();

    public IInitializable[] GetInitializables();
}
