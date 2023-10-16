using Services;
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
            builder.Register<PlayerPrefsPlayerDataProvider>(Lifetime.Singleton);
            builder.Register<StateMachine>(Lifetime.Singleton);
        }

        private void Start()
        {
            Application.targetFrameRate = 999999;
            QualitySettings.vSyncCount = 0;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}