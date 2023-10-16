using Bombs;
using Services.Data;
using Zenject;

namespace Services.Factories
{
    public class BombFactory
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        [Inject]
        private BombFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public Bomb Create(int skinIndex)
        {
            var bomb = _container.InstantiatePrefabForComponent<Bomb>(_configProvider.BombSkinsConfig.Bombs[skinIndex].gameObject);
            return bomb.GetComponent<Bomb>();
        }
    }
}