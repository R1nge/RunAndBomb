using Data;
using UnityEngine;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataProvider _dataProvider;
        private readonly PlayerStatisticsModel _playerStatisticsModel;
        private readonly UIService _uiService;

        public WinGameState(IPlayerDataProvider dataProvider, PlayerStatisticsModel playerStatisticsModel, UIService uiService)
        {
            _dataProvider = dataProvider;
            _playerStatisticsModel = playerStatisticsModel;
            _uiService = uiService;
        }

        public void Enter()
        {
            //TODO: Delete player controls
            _playerStatisticsModel.Level++;
            _dataProvider.Save(_playerStatisticsModel);
            _uiService.ShowWinScreen();
            Debug.Log($"[WIN] Level: {_playerStatisticsModel.Level}");
        }

        public void Exit() { }
    }
}