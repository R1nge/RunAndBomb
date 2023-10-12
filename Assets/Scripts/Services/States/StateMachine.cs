using System.Collections.Generic;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Dictionary<StateType, IState> _states = new();
        private IState _currentState;

        public void AddState(StateType stateType, IState newState) => _states[stateType] = newState;

        public void ChangeState(StateType stateType)
        {
            _currentState?.Exit();
            _currentState = _states[stateType];
            _currentState.Enter();
        }
    }
}