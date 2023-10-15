using System;
using Data;
using Enemies;

namespace Services
{
    public class EnemySkinService
    {
        private readonly Random _random = new();
        private readonly ConfigProvider _configProvider;

        private EnemySkinService(ConfigProvider configProvider) => _configProvider = configProvider;

        public Enemy GetRandomSkin()
        {
            EnemySkinsConfig enemyConfig = _configProvider.EnemySkinsConfig;
            var index = _random.Next(0, enemyConfig.Skins.Length);
            var skin = enemyConfig.Skins[index];
            return skin;
        }
    }
}