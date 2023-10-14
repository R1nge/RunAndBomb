using Data;

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

        public void Enter() => _dataProvider.Save(_playerStatisticsModel);

        public void Exit() { }
    }
}