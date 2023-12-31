﻿using System;

namespace Services
{
    public class EnemyCounter
    {
        public event Action<int> OnEnemyCountChanged;
        private int _enemyCount;

        public int EnemyCount => _enemyCount;

        public void Increase()
        {
            _enemyCount++;
            OnEnemyCountChanged?.Invoke(_enemyCount);
        }

        public void Decrease()
        {
            _enemyCount--;
            OnEnemyCountChanged?.Invoke(_enemyCount);
        }

        public void Reset() => _enemyCount = 0;
    }
}