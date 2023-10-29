using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Services
{
    public class RestartService
    {
        private readonly List<Enemy> _enemies = new();
        private readonly PlayerReferenceHolder _playerReferenceHolder;
        private readonly EnemyCounter _enemyCounter;

        private RestartService(EnemyCounter enemyCounter, PlayerReferenceHolder playerReferenceHolder)
        {
            _enemyCounter = enemyCounter;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public void Restart()
        {
            DestroyEnemies();
            DestroyPlayer();
            ResetCamera();
        }

        public void AddEnemy(Enemy enemy) => _enemies.Add(enemy);

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
            if (_playerReferenceHolder.Player != null)
            {
                Object.Destroy(_playerReferenceHolder.Player.gameObject);
                _playerReferenceHolder.SetPlayer(null);
            }
        }

        private void ResetCamera() { }
    }
}