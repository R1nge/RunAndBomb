using System.Collections.Generic;
using Services.Data;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly StateMachine _stateMachine;
        private readonly UIService _uiService;

        private LoadingScreen _loadingScreen;

        public LoadDataState(StateMachine stateMachine, IPlayerDataService playerDataService, UIService uiService)
        {
            _playerDataService = playerDataService;
            _stateMachine = stateMachine;
            _uiService = uiService;
        }

        public void Enter()
        {
            _loadingScreen = _uiService.ShowLoadingScreen();

            var loadings = new List<ILoadingOperation>
            {
                new DataLoadingOperation(_playerDataService)
            };

            _loadingScreen.UpdatePercent(0, loadings.Count);

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
                _loadingScreen.UpdatePercent(i + 1, loadings.Count);
            }

            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() => _loadingScreen.Destroy();
    }
}