using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        public async void Enter()
        {
            _loadingScreen = await _uiService.ShowLoadingScreen();

            //Placeholder code for the demonstration purposes.
            var asyncLoadings = new List<IAsyncLoadingOperation>
            {
                new AsyncPlaceHolderLoadingOperation()
            };

            var loadings = new List<ILoadingOperation>
            {
                new DataLoadingOperation(_playerDataService),
            };


            int total = loadings.Count + asyncLoadings.Count;

            _loadingScreen.UpdatePercent(0, total);

            var current = 0;

            for (int i = 0; i < asyncLoadings.Count; i++)
            {
                await asyncLoadings[i].Load();
                current++;
                _loadingScreen.UpdatePercent(current + 1, loadings.Count);
            }

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
                current++;
                _loadingScreen.UpdatePercent(current + 1, loadings.Count);
            }

            await Task.Delay(1000);

            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}