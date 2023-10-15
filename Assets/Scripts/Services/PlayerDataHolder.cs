using Data;

namespace Services
{
    public class PlayerDataHolder
    {
        public PlayerStatisticsModel PlayerStatisticsModel
        {
            get => _playerStatisticsModel;
            set => _playerStatisticsModel = value;
        }

        private PlayerStatisticsModel _playerStatisticsModel;
    }
}