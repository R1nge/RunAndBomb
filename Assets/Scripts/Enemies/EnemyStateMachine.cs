using System.Collections.Generic;

namespace Enemies
{
    public class EnemyStateMachine
    {
        private readonly Dictionary<EnemyStateType, IEnemyState> _states = new();
        private IEnemyState _currentEnemyState;
        private EnemyStateType _currentEnemyStateType;

        public EnemyStateType CurrentEnemyStateType => _currentEnemyStateType;

        public void AddState(EnemyStateType gameStateType, IEnemyState newGameState) => _states[gameStateType] = newGameState;

        public void ChangeState(EnemyStateType enemyStateType)
        {
            _currentEnemyState?.Exit();
            _currentEnemyState = _states[enemyStateType];
            _currentEnemyState.Enter();
            _currentEnemyStateType = enemyStateType;
        }

        public void Update() => _currentEnemyState?.Update();
    }
}