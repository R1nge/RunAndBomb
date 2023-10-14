using System.Collections.Generic;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states = new();
        private IGameState _currentGameState;

        public void AddState(GameStateType gameStateType, IGameState newGameState) => _states[gameStateType] = newGameState;

        public void ChangeState(GameStateType gameStateType)
        {
            _currentGameState?.Exit();
            _currentGameState = _states[gameStateType];
            _currentGameState.Enter();
        }
    }
}