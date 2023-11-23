using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Data;
using Services.Data.Player;
using Services.Data.Settings;
using UnityEngine;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly IPlayerDataService _playerDataService;
        private readonly ISettingsDataService _settingsDataService;
        private readonly UIService _uiService;
        private readonly LocalizationService _localizationService;

        public LoadDataState(StateMachine stateMachine, IPlayerDataService playerDataService, ISettingsDataService settingsDataService, UIService uiService, LocalizationService localizationService)
        {
            _stateMachine = stateMachine;
            _playerDataService = playerDataService;
            _settingsDataService = settingsDataService;
            _uiService = uiService;
            _localizationService = localizationService;
        }

        public async void Enter()
        {
            //TODO: create a loading service
            LoadingScreen loadingScreen = await _uiService.ShowLoadingScreen();

            var asyncLoadings = new List<IAsyncLoadingOperation>
            {
                new AsyncPlaceHolderLoadingOperation()
            };

            var loadings = new List<ILoadingOperation>
            {
                new PlayerDataLoadingOperation(_playerDataService),
                new SettingsDataLoadingOperation(_settingsDataService)
            };

            int total = loadings.Count + asyncLoadings.Count;

            loadingScreen.UpdatePercent(0, total);

            var current = 0;

            for (int i = 0; i < asyncLoadings.Count; i++)
            {
                await asyncLoadings[i].Load();
                current++;
                loadingScreen.UpdatePercent(current + 1, loadings.Count);
            }

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
                current++;
                loadingScreen.UpdatePercent(current + 1, loadings.Count);
            }
            
            await _localizationService.SetLocalization(_settingsDataService.Model.Language);

            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}