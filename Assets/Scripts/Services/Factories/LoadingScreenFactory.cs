using Services.Data;
using Zenject;

namespace Services.Factories
{
    public class LoadingScreenFactory : IUIFactory<LoadingScreen>
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private LoadingScreenFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }
        
        public LoadingScreen Create() => _container.InstantiatePrefabForComponent<LoadingScreen>(_configProvider.UIConfig.LoadingScreen);
    }
}