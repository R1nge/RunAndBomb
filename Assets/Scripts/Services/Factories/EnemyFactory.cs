using Enemies;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class EnemyFactory
    {
        private readonly DiContainer _container;
        private readonly EnemySkinService _enemySkinService;
        private readonly EnemyCounter _enemyCounter;

        private readonly RestartService _restartService;

        private EnemyFactory(DiContainer container, EnemySkinService enemySkinService, EnemyCounter enemyCounter, RestartService restartService)
        {
            _container = container;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _restartService = restartService;
        }

        public Enemy Create()
        {
            var enemy = _container.InstantiatePrefabForComponent<Enemy>(_enemySkinService.GetRandomSkin());
            _restartService.AddEnemy(enemy);
            enemy.GetComponent<NicknameUI>().SetNickname(NameGenerator.GenerateName());
            _enemyCounter.Increase();
            return enemy;
        }
    }
}