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

        public Platform CreateBase()
        {
            var basePlatform = _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.BasePlatform);
            return basePlatform;
        }

        public Platform CreateCircle(int index)
        {
            var circlePlatform = _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.Platforms[index]);
            return circlePlatform;
        }
    }
}