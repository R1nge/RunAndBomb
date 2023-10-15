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
        private readonly ConfigProvider _configProvider;

        private EnemyFactory(IObjectResolver objectResolver, EnemySkinService enemySkinService,
            EnemyCounter enemyCounter, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _enemySkinService = enemySkinService;
            _enemyCounter = enemyCounter;
            _configProvider = configProvider;
        }

        public void Create()
        {
            EnemyConfig enemyConfig = _configProvider.EnemyConfig;
            for (int i = 0; i < enemyConfig.SpawnPositions.Length; i++)
            {
                Enemy enemy = _objectResolver.Instantiate(_enemySkinService.GetRandomSkin(), enemyConfig.SpawnPositions[i], Quaternion.identity);
                enemy.GetComponent<NicknameUI>().SetNickname(i.ToString());
                _enemyCounter.Increase();
            }
        }
    }
}