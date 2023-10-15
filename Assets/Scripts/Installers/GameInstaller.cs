using Data;
using Services;
using Services.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private EnemySkinsConfig enemySkinsConfig;
        [SerializeField] private BombSkinsConfig bombSkinsConfig;
        [SerializeField] private UIConfig uiConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(playerConfig);
            builder.RegisterInstance(enemyConfig);
            builder.RegisterInstance(enemySkinsConfig);
            builder.RegisterInstance(bombSkinsConfig);
            builder.RegisterInstance(uiConfig);
            builder.RegisterComponent(coroutineRunner);
            
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