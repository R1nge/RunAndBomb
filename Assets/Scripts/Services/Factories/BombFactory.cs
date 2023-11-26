using Bombs;
using Services.Data;
using Zenject;

namespace Services.Factories
{
    public class BombFactory
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;
        private readonly RestartService _restartService;

        [Inject]
        private BombFactory(DiContainer container, ConfigProvider configProvider, RestartService restartService)
        {
            _container = container;
            _configProvider = configProvider;
            _restartService = restartService;
        }

        public Bomb Create(int skinIndex)
        {
            var bomb =  _container.InstantiatePrefabForComponent<Bomb>(_configProvider.BombSkinsConfig.Bombs[skinIndex]);
            _restartService.AddBomb(bomb);
            return bomb;
        }
    }
}