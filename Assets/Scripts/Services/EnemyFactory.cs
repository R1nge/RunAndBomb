using Enemies;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly Enemy _enemy;
        private readonly EnemyCounter _enemyCounter;

        public EnemyFactory(IObjectResolver objectResolver, Enemy enemy, EnemyCounter enemyCounter)
        {
            _objectResolver = objectResolver;
            _enemy = enemy;
            _enemyCounter = enemyCounter;
        }

        public void Spawn()
        {
            _objectResolver.Instantiate(_enemy);
            _enemyCounter.Increase();
        }
    }
}