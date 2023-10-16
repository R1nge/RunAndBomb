namespace Services.States
{
    public class ResetState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly CoroutineRunner _coroutineRunner;

        public ResetState(StateMachine stateMachine, CoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StopCoroutines();
            
            _stateMachine.ChangeState(GameStateType.Init);
        }

        public void Exit() { }
    }
}