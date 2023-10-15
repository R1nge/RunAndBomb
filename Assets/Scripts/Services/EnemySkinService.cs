using System;
using Data;
using Enemies;

namespace Services
{
    public class EnemySkinService
    {
        private readonly Random _random = new();
        private readonly EnemySkinsConfig _enemySkins;

        private EnemySkinService(EnemySkinsConfig enemySkins) => _enemySkins = enemySkins;

        public Enemy GetRandomSkin()
        {
            var index = _random.Next(0, _enemySkins.Skins.Length);
            var skin = _enemySkins.Skins[index];
            return skin;
        }
    }
}