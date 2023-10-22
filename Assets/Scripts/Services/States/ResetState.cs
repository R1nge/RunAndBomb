namespace Services.States
{
    public class ResetState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly RestartService _restartService;

        public ResetState(StateMachine stateMachine, CoroutineRunner coroutineRunner, RestartService restartService)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
            _restartService = restartService;
        }

        public void Enter()
        {
            _restartService.Restart();
            _coroutineRunner.StopCoroutines();
            _stateMachine.ChangeState(GameStateType.Init);
        }

        public void Exit() { }
    }
}