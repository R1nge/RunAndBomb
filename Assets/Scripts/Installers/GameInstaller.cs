using Services;
using Services.Data;
using Services.Factories;
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
            
            Container.Bind<StartScreenFactory>().AsSingle();
            Container.Bind<GamePlayScreenFactory>().AsSingle();
            Container.Bind<WinScreenFactory>().AsSingle();
            Container.Bind<LoseScreenFactory>().AsSingle();
            Container.Bind<UIService>().AsSingle();
            
            Container.Bind<PlayerFactory>().AsSingle();

            Container.Bind<BombFactory>().AsSingle();
            Container.Bind<EnemySkinService>().AsSingle();
            Container.Bind<EnemyCounter>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();

            Container.Bind<StateMachine>().AsSingle();

            
            Container.BindInterfacesTo<WinService>().AsSingle();
        }
    }
}