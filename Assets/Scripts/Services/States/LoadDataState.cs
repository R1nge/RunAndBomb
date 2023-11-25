using Services.Data;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingService _loadingService;
        

        public LoadDataState(StateMachine stateMachine, LoadingService loadingService)
        {
            _stateMachine = stateMachine;
            _loadingService = loadingService;
        }

        public async void Enter()
        {
            await _loadingService.Load();
            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}