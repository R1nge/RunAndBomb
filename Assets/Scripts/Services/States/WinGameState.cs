using Data;
using UnityEngine;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataProvider _dataProvider;
        private readonly PlayerStatisticsModel _playerStatisticsModel;

        public WinGameState(IPlayerDataProvider dataProvider, PlayerStatisticsModel playerStatisticsModel)
        {
            _dataProvider = dataProvider;
            _playerStatisticsModel = playerStatisticsModel;
        }

        public void Enter()
        {
            _playerStatisticsModel.Level++;
            _dataProvider.Save(_playerStatisticsModel);
            
            Debug.Log($"[WIN] Level: {_playerStatisticsModel.Level}");
        }

        public void Exit() { }
    }
}