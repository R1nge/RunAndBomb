using Data;
using Enemies;
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
        private readonly EnemyConfig _enemyConfig;

        private EnemyFactory(IObjectResolver objectResolver, EnemySkinService enemySkinService, EnemyCounter enemyCounter, EnemyConfig enemyConfig)
        {
            _objectResolver = objectResolver;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _enemyConfig = enemyConfig;
        }

        public void Create()
        {
            for (int i = 0; i < _enemyConfig.SpawnPositions.Length; i++)
            {
                Enemy enemy = _objectResolver.Instantiate(_enemySkinService.GetRandomSkin(), _enemyConfig.SpawnPositions[i], Quaternion.identity);
                enemy.GetComponent<NicknameUI>().SetNickname(i.ToString());
                _enemyCounter.Increase();
            }
        }
    }
}