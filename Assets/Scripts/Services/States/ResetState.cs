using Services.Maps;

namespace Services.States
{
    public class ResetState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly RestartService _restartService;
        private readonly MapService _mapService;

        public ResetState(StateMachine stateMachine, CoroutineRunner coroutineRunner, RestartService restartService, MapService mapService)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
            _restartService = restartService;
            _mapService = mapService;
        }

        public void Enter()
        {
            _mapService.DestroyMap();
            _restartService.Restart();
            _coroutineRunner.StopCoroutines();
            _stateMachine.ChangeState(GameStateType.Init);
        }

        public void Exit() { }
    }
}