using Services;
using Services.Data;
using Services.Factories;
using Services.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private SpawnPositionsProvider spawnPositionsProvider;
        //[SerializeField] private PlatformService platformService;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(spawnPositionsProvider);
            //builder.RegisterComponent(platformService);
            builder.Register<PlayerFactory>(Lifetime.Singleton);

            builder.Register<BombFactory>(Lifetime.Singleton);
            builder.Register<EnemySkinService>(Lifetime.Singleton);
            builder.Register<EnemyCounter>(Lifetime.Singleton);
            builder.Register<EnemyFactory>(Lifetime.Singleton);

            builder.Register<StateMachine>(Lifetime.Singleton);
        }
    }
}