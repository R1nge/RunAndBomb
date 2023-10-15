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
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private ConfigProvider configProvider;
        [SerializeField] private SpawnPositionsProvider spawnPositionsProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(configProvider);
            builder.RegisterComponent(coroutineRunner);
            builder.RegisterComponent(spawnPositionsProvider);
            
            builder.Register<PlayerDataHolder>(Lifetime.Singleton);
            builder.Register<PlayerPrefsPlayerDataProvider>(Lifetime.Singleton);
            
            builder.Register<StateMachine>(Lifetime.Singleton);
            builder.Register<EnemySkinService>(Lifetime.Singleton);
            builder.Register<EnemyCounter>(Lifetime.Singleton);
            builder.Register<BombFactory>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<EnemyFactory>(Lifetime.Singleton);
            
            builder.Register<StartScreenFactory>(Lifetime.Singleton);
            builder.Register<GamePlayScreenFactory>(Lifetime.Singleton);
            builder.Register<WinScreenFactory>(Lifetime.Singleton);
            builder.Register<LoseScreenFactory>(Lifetime.Singleton);
            builder.Register<UIService>(Lifetime.Singleton);
        }
    }
}