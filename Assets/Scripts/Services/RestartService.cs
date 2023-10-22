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
        private readonly List<Platform> _platforms = new();
        private readonly List<Enemy> _enemies = new();
        private readonly List<Bomb> _bombs = new();
        private Player _player;
        //TODO: camera service
        private readonly EnemyCounter _enemyCounter;

        private RestartService(EnemyCounter enemyCounter) => _enemyCounter = enemyCounter;

        public void Restart()
        {
            DestroyMap();
            DestroyEnemies();
            DestroyBombs();
            DestroyPlayer();
            ResetCamera();
        }

        public void AddPlatform(Platform platform) => _platforms.Add(platform);

        public void AddEnemy(Enemy enemy) => _enemies.Add(enemy);

        public void AddBomb(Bomb bomb) => _bombs.Add(bomb);

        public void SetPlayer(Player player) => _player = player;

        private void DestroyMap()
        {
            for (int i = _platforms.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_platforms[i].gameObject);
            }

            _platforms.Clear();
        }

        private void DestroyEnemies()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_enemies[i].gameObject);
            }

            _enemyCounter.Reset();
            _enemies.Clear();
        }

        private void DestroyBombs()
        {
            for (int i = _bombs.Count - 1; i >= 0; i--)
            {
                Object.Destroy(_bombs[i].gameObject);
            }

            _bombs.Clear();
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