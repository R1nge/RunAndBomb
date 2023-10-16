using System;
using Services.States;
using UnityEngine;
using Zenject;

namespace Services
{
    //TODO: think of a better name
    public class GameEnder : IInitializable, IDisposable
    {
        private readonly StateMachine _stateMachine;
        private readonly EnemyCounter _enemyCounter;

        private GameEnder(StateMachine stateMachine, EnemyCounter enemyCounter)
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