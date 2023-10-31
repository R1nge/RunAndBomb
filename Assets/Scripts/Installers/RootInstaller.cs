using Services;
using Services.Assets;
using Services.Data;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private ConfigProvider configProvider;

        public override void InstallBindings()
        {
            Container.BindInstance(coroutineRunner);
            Container.BindInstance(configProvider);

            Container.Bind<PlayerDataHolder>().AsSingle();
            Container.BindInterfacesTo<PlayerPrefsPlayerDataProvider>().AsSingle();
            Container.BindInterfacesTo<PlayerDataService>().AsSingle();
            
            Container.Bind<LoadingScreenAssetProvider>().AsSingle();
            Container.Bind<StartScreenAssetProvider>().AsSingle();

            Container.Bind<SettingsService>().AsSingle();
            Container.Bind<VibrationService>().AsSingle();
        }
    }
}