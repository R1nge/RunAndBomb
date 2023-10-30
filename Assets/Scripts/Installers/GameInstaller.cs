using Players;
using Services;
using Services.Assets;
using Services.Data;
using Services.Factories;
using Services.Maps;
using Services.States;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SoundService soundService;

        public override void InstallBindings()
        {
            Container.BindInstance(soundService);

            Container.Bind<SpawnPositionsProvider>().AsSingle();
            Container.Bind<CameraService>().AsSingle();
            Container.Bind<InputService>().AsSingle();

            Container.Bind<PlatformFactory>().AsSingle();
            Container.Bind<MapService>().AsSingle();

            Container.Bind<InGameUIAssetProvider>().AsSingle();
            Container.Bind<WinUIAssetProvider>().AsSingle();
            Container.Bind<LoseScreenAssetProvider>().AsSingle();

            Container.Bind<LoadingScreenFactory>().AsSingle();
            Container.Bind<StartScreenFactory>().AsSingle();
            Container.Bind<GamePlayScreenFactory>().AsSingle();
            Container.Bind<WinScreenFactory>().AsSingle();
            Container.Bind<LoseScreenFactory>().AsSingle();
            Container.Bind<UIService>().AsSingle();

            Container.Bind<PlayerReferenceHolder>().AsSingle();
            Container.Bind<PlayerAssetProvider>().AsSingle();
            Container.Bind<PlayerFactory>().AsSingle();
            
            Container.Bind<ExplosionVFXFactory>().AsSingle();

            Container.Bind<BombFactory>().AsSingle();
            Container.Bind<EnemySkinService>().AsSingle();
            Container.Bind<EnemyCounter>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<EnemySpawner>().AsSingle();

            Container.Bind<StateMachine>().AsSingle();

            Container.Bind<RestartService>().AsSingle();
            Container.BindInterfacesTo<WinService>().AsSingle();
        }
    }
}