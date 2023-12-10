using Assets.Scripts.AssetManagment;
using Assets.Scripts.Data;
using Assets.Scripts.Features;
using Assets.Scripts.Levels;
using Assets.Scripts.Shop;
using Assets.Scripts.UI.Windows;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindowController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesAssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UserDataContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<Player>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<DailyReward>().AsSingle();




            var async = SceneManager.LoadSceneAsync("Game");
        
            
        }

    }

    
}