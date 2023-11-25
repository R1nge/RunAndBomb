using Enemies;
using Services.Data;
using Services.Factories;

namespace Services
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly ConfigProvider _configProvider;

        private EnemySpawner(EnemyFactory enemyFactory, SpawnPositionsProvider spawnPositionsProvider, ConfigProvider configProvider)
        {
            _enemyFactory = enemyFactory;
            _spawnPositionsProvider = spawnPositionsProvider;
            _configProvider = configProvider;
        }

        public async void Spawn()
        {
            for (int i = 1; i < _configProvider.MapConfig.SpawnPositionsAmount; i++)
            {
                Enemy enemy = await _enemyFactory.Create();
                enemy.transform.position = _spawnPositionsProvider.SpawnPositions[i];
            }
        }
    }
}