using System;

namespace Services
{
    public class EnemyCounter
    {
        public event Action<int> OnCountChanged;
        private int _enemyCount;

        public void Increase()
        {
            _enemyCount++;
            OnCountChanged?.Invoke(_enemyCount);
        }

        public void Decrease()
        {
            _enemyCount--;
            OnCountChanged?.Invoke(_enemyCount);
        }
    }
}