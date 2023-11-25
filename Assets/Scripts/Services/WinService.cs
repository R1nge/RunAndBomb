using System;
using Services.States;
using Zenject;

namespace Services
{
    public class WinService : IInitializable, IDisposable
    {
        private readonly StateMachine _stateMachine;
        private readonly EnemyCounter _enemyCounter;

        private WinService(StateMachine stateMachine, EnemyCounter enemyCounter)
        {
            _stateMachine = stateMachine;
            _enemyCounter = enemyCounter;
        }

        public void Initialize() => _enemyCounter.OnEnemyCountChanged += CheckIfCanEndGame;

        private void CheckIfCanEndGame(int enemiesLeft)
        {
            if (enemiesLeft == 0)
            {
                _stateMachine.ChangeState(GameStateType.Win);
            }
        }

        public void Dispose() => _enemyCounter.OnEnemyCountChanged -= CheckIfCanEndGame;
    }
}