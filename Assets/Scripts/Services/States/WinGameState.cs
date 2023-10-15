using Data;
using UnityEngine;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataProvider _dataProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly UIService _uiService;

        public WinGameState(IPlayerDataProvider dataProvider, PlayerDataHolder playerDataHolder, UIService uiService)
        {
            _dataProvider = dataProvider;
            _playerDataHolder = playerDataHolder;
            _uiService = uiService;
        }

        public void Enter()
        {
            //TODO: Delete player controls
            PlayerStatisticsModel model = _playerDataHolder.PlayerStatisticsModel;
            model.Level++;
            _dataProvider.Save(model);
            _uiService.ShowWinScreen();
            Debug.Log($"[WIN] Level: {model.Level}");
        }

        public void Exit() { }
    }
}