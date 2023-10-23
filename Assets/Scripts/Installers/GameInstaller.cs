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
        [SerializeField] private SpawnPositionsProvider spawnPositionsProvider;
        //[SerializeField] private PlatformService platformService;

        public override void InstallBindings()
        {
            Container.BindInstance(spawnPositionsProvider);
            //builder.RegisterComponent(platformService);

            Container.Bind<InputService>().AsSingle();

            Container.Bind<PlatformDataHolder>().AsSingle();
            Container.Bind<PlatformFactory>().AsSingle();
            Container.Bind<MapGenerator>().AsSingle();
            Container.Bind<MapDestructor>().AsSingle();

            Container.Bind<InGameUIAssetProvider>().AsSingle();
            Container.Bind<WinUIAssetProvider>().AsSingle();
            Container.Bind<LoseScreenAssetProvider>().AsSingle();

            Container.Bind<LoadingScreenFactory>().AsSingle();
            Container.Bind<StartScreenFactory>().AsSingle();
            Container.Bind<GamePlayScreenFactory>().AsSingle();
            Container.Bind<WinScreenFactory>().AsSingle();
            Container.Bind<LoseScreenFactory>().AsSingle();
            Container.Bind<UIService>().AsSingle();

            Container.Bind<PlayerAssetProvider>().AsSingle();
            Container.Bind<PlayerFactory>().AsSingle();

            Container.Bind<BombFactory>().AsSingle();
            Container.Bind<EnemySkinService>().AsSingle();
            Container.Bind<EnemyCounter>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();

            Container.Bind<StateMachine>().AsSingle();

            Container.Bind<RestartService>().AsSingle();
            Container.BindInterfacesTo<WinService>().AsSingle();
        }
    }
}