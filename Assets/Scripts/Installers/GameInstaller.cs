﻿using Data;
using Services;
using Services.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private BombSkinsConfig bombSkinsConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(bombSkinsConfig);
            builder.Register<BombFactory>(Lifetime.Singleton);
            builder.Register<EnemyCounter>(Lifetime.Singleton);
            builder.Register<StateMachine>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<EntryPoint>();
        }
    }
}