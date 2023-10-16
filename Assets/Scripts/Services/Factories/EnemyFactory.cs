using Enemies;
using Services.Data;
using UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EnemySkinService _enemySkinService;
        private readonly EnemyCounter _enemyCounter;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;

        private EnemyFactory(IObjectResolver objectResolver, EnemySkinService enemySkinService,
            EnemyCounter enemyCounter, SpawnPositionsProvider spawnPositionsProvider)
        {
            _objectResolver = objectResolver;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _spawnPositionsProvider = spawnPositionsProvider;
        }

        public void Create()
        {
            for (int i = 1; i < _spawnPositionsProvider.SpawnPositions.Length; i++)
            {
                Enemy enemy = _objectResolver.Instantiate(_enemySkinService.GetRandomSkin(), _spawnPositionsProvider.SpawnPositions[i].position, Quaternion.identity);
                enemy.GetComponent<NicknameUI>().SetNickname(i.ToString());
                _enemyCounter.Increase();
            }
        }
    }
}