using Services.Maps;

namespace Services.States
{
    public class ResetState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly RestartService _restartService;
        private readonly MapDestructor _mapDestructor;

        public ResetState(StateMachine stateMachine, CoroutineRunner coroutineRunner, RestartService restartService, MapDestructor mapDestructor)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
            _restartService = restartService;
            _mapDestructor = mapDestructor;
        }

        public void Enter()
        {
            _mapDestructor.DestroyMap();
            _restartService.Restart();
            _coroutineRunner.StopCoroutines();
            _stateMachine.ChangeState(GameStateType.Init);
        }

        public void Exit() { }
    }
}