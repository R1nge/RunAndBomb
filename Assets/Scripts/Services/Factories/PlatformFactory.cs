using Services.Data;
using Services.Maps;
using Zenject;

namespace Services.Factories
{
    public class PlatformFactory
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;
        private readonly RestartService _restartService;

        private PlatformFactory(DiContainer container, ConfigProvider configProvider, RestartService restartService)
        {
            _container = container;
            _configProvider = configProvider;
            _restartService = restartService;
        }

        public Platform CreateBase()
        {
            var basePlatform = _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.BasePlatform);
            _restartService.AddPlatform(basePlatform);
            return basePlatform;
        }

        public Platform CreateCircle(int index)
        {
            var circlePlatform = _container.InstantiatePrefabForComponent<Platform>(_configProvider.MapConfig.Platforms[index]);
            _restartService.AddPlatform(circlePlatform);
            return circlePlatform;
        }
    }
}