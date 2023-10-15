using System;
using Services.States;

namespace Services
{
    public class EnemyCounter
    {
        public event Action<int> OnEnemyCountChanged;
        private int _enemyCount;
        private readonly StateMachine _stateMachine;

        public int EnemyCount => _enemyCount;

        private EnemyCounter(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void Increase()
        {
            _enemyCount++;
            OnEnemyCountChanged?.Invoke(_enemyCount);
        }

        public void Decrease()
        {
            _enemyCount--;
            OnEnemyCountChanged?.Invoke(_enemyCount);

            if (_enemyCount <= 0)
            {
                _stateMachine.ChangeState(GameStateType.Win);
            }
        }
    }
}