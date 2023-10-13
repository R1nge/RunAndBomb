using Bombs;
using Data;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class BombFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly BombSkinsConfig _bombSkinsConfig;

        [Inject]
        private BombFactory(IObjectResolver objectResolver, BombSkinsConfig bombSkinsConfig)
        {
            _objectResolver = objectResolver;
            _bombSkinsConfig = bombSkinsConfig;
        }

        public Bomb Create(int skinIndex)
        {
            var bomb = _objectResolver.Instantiate(_bombSkinsConfig.Bombs[skinIndex].gameObject);
            return bomb.GetComponent<Bomb>();
        }
    }
}