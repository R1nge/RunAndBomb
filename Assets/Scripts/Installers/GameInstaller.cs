using Services;
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

        protected override void Configure(IContainerBuilder builder)
        {
            

            //Game installer
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<EnemyFactory>(Lifetime.Singleton);
            builder.Register<EnemyCounter>(Lifetime.Singleton);
            builder.RegisterComponent(spawnPositionsProvider);
            
            builder.Register<EnemySkinService>(Lifetime.Singleton);
            builder.Register<BombFactory>(Lifetime.Singleton);
            
            //Game installer ???
            builder.Register<StartScreenFactory>(Lifetime.Singleton);
            builder.Register<GamePlayScreenFactory>(Lifetime.Singleton);
            builder.Register<WinScreenFactory>(Lifetime.Singleton);
            builder.Register<LoseScreenFactory>(Lifetime.Singleton);
            builder.Register<UIService>(Lifetime.Singleton);
        }
    }
}