using System.Collections.Generic;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Queue<IState> _states = new();
        private IState _currentState;

        public void AddState(IState newState) => _states.Enqueue(newState);

        public void ChangeState()
        {
            _currentState?.Exit();
            _currentState = _states.Dequeue();
            _currentState.Enter();
        }
    }
}