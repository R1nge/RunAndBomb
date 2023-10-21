using Services.Data;
using Services.Maps;
using Zenject;

namespace Services.Factories
{
    public class PlatformFactory
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private PlatformFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public Platform CreateBase() => _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.BasePlatform);

        public Platform CreateCircle(int index) => _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.Platforms[index]);
    }
}