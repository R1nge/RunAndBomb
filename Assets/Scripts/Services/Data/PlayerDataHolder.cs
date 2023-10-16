using Data;

namespace Services.Data
{
    public class PlayerDataHolder
    {
        public PlayerDataHolder() => _playerStatisticsModel = new PlayerStatisticsModel("", 1);

        public PlayerStatisticsModel PlayerStatisticsModel
        {
            get => _playerStatisticsModel;
            set => _playerStatisticsModel = value;
        }

        private PlayerStatisticsModel _playerStatisticsModel;
    }
}