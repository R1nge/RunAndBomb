using Data;

namespace Services
{
    public class PlayerDataHolder
    {
        private readonly PlayerStatisticsModel _playerStatisticsModel;

        public PlayerDataHolder(PlayerStatisticsModel playerStatisticsModel)
        {
            _playerStatisticsModel = playerStatisticsModel;
        }

        public PlayerStatisticsModel PlayerStatisticsModel => _playerStatisticsModel;
    }
}