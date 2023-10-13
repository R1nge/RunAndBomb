using VContainer;
using VContainer.Unity;

namespace Services
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EnemySkinService _enemySkinService;
        private readonly EnemyCounter _enemyCounter;

        public EnemyFactory(IObjectResolver objectResolver, EnemySkinService enemySkinService, EnemyCounter enemyCounter)
        {
            _objectResolver = objectResolver;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
        }

        public void Create()
        {
            _objectResolver.Instantiate(_enemySkinService.GetRandomSkin());
            _enemyCounter.Increase();
        }
    }
}