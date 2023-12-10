using Assets.Scripts.AssetManagment;
using Assets.Scripts.Data;
using Assets.Scripts.Features;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.Windows;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ProjectInitializer : MonoInstaller
    {

        [Inject] private WindowController _windowController;
        [Inject] private ResourcesAssetProvider _resourcesAssetProvider;
        [Inject] private SaveLoadService _saveLoadService;

        public override void InstallBindings()
        {
            _windowController.Initialize();
            _resourcesAssetProvider.Initialize();
            _saveLoadService.Initialize();
            
        }



    }
}