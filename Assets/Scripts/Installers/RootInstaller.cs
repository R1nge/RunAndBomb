﻿using Services;
using Services.Data;
using Services.Factories;
using Services.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class RootInstaller : LifetimeScope
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private ConfigProvider configProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(coroutineRunner);
            builder.RegisterComponent(configProvider);
            
            builder.Register<PlayerDataHolder>(Lifetime.Singleton);
            builder.Register<PlayerPrefsPlayerDataProvider>(Lifetime.Singleton).As<IPlayerDataProvider>();
            builder.Register<PlayerDataService>(Lifetime.Singleton).As<IPlayerDataService>();

            builder.Register<StartScreenFactory>(Lifetime.Singleton);
            builder.Register<GamePlayScreenFactory>(Lifetime.Singleton);
            builder.Register<WinScreenFactory>(Lifetime.Singleton);
            builder.Register<LoseScreenFactory>(Lifetime.Singleton);
            builder.Register<UIService>(Lifetime.Singleton);
        }

        private void Start()
        {
            Application.targetFrameRate = 999999;
            QualitySettings.vSyncCount = 0;
        }
    }
}