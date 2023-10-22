using Enemies;
using Services.Data;
using UIs;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class EnemyFactory
    {
        private readonly DiContainer _container;
        private readonly EnemySkinService _enemySkinService;
        private readonly EnemyCounter _enemyCounter;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly RestartService _restartService;

        private EnemyFactory(DiContainer container, EnemySkinService enemySkinService,
            EnemyCounter enemyCounter, SpawnPositionsProvider spawnPositionsProvider, RestartService restartService)
        {
            _container = container;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _spawnPositionsProvider = spawnPositionsProvider;
            _restartService = restartService;
        }

        public void Create()
        {
            for (int i = 1; i < _spawnPositionsProvider.SpawnPositions.Length; i++)
            {
                var enemy = _container.InstantiatePrefabForComponent<Enemy>(_enemySkinService.GetRandomSkin(), _spawnPositionsProvider.SpawnPositions[i].position, Quaternion.identity, null);
                _restartService.AddEnemy(enemy);
                enemy.GetComponent<NicknameUI>().SetNickname(i.ToString());
                _enemyCounter.Increase();
            }
        }
    }
}