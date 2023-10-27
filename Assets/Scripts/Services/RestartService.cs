using System.Collections.Generic;
using Bombs;
using Enemies;
using Players;
using Services.Maps;
using UnityEngine;

namespace Services
{
    public class RestartService
    {
        private readonly List<Enemy> _enemies = new();
        private Player _player;
        //TODO: camera service
        private readonly EnemyCounter _enemyCounter;

        private RestartService(EnemyCounter enemyCounter)
        {
            _enemyCounter = enemyCounter;
        }

        public void Restart()
        {
            DestroyEnemies();
            DestroyPlayer();
            ResetCamera();
        }

        public void AddEnemy(Enemy enemy) => _enemies.Add(enemy);

        public void SetPlayer(Player player) => _player = player;

        private void DestroyEnemies()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_enemies[i].gameObject);
            }

            _enemyCounter.Reset();
            _enemies.Clear();
        }

        private void DestroyPlayer()
        {
            if (_player != null)
            {
                Object.Destroy(_player.gameObject);
            }
        }

        private void ResetCamera() { }
    }
}