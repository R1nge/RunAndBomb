using Bombs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class BombFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        [Inject]
        private BombFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public Bomb Create(int skinIndex)
        {
            var bomb = _objectResolver.Instantiate(_configProvider.BombSkinsConfig.Bombs[skinIndex].gameObject);
            return bomb.GetComponent<Bomb>();
        }
    }
}