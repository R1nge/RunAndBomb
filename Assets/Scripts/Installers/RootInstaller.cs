using Services;
using Services.Assets;
using Services.Data;
using Services.Data.Player;
using Services.Data.Settings;
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

            Container.BindInterfacesTo<PlayerPrefsPlayerDataProvider>().AsSingle();
            Container.BindInterfacesTo<PlayerDataService>().AsSingle();

            Container.BindInterfacesTo<PlayerPrefsSettingsDataProvider>().AsSingle();
            Container.BindInterfacesTo<SettingsDataService>().AsSingle();

            Container.Bind<NotificationService>().AsSingle();
            Container.Bind<LocalizationService>().AsSingle();

            Container.Bind<SettingsService>().AsSingle();
            Container.Bind<VibrationService>().AsSingle();

            Container.Bind<LoadingScreenAssetProvider>().AsSingle();
            Container.Bind<StartScreenAssetProvider>().AsSingle();
        }
    }
}