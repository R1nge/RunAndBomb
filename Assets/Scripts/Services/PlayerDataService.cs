using Data;

namespace Services
{
    public class PlayerDataService : IPlayerDataService
    {
        private readonly IPlayerDataProvider _playerDataProvider;
        private readonly PlayerDataHolder _playerDataHolder;

        public PlayerDataService(IPlayerDataProvider playerDataProvider, PlayerDataHolder playerDataHolder)
        {
            _playerDataProvider = playerDataProvider;
            _playerDataHolder = playerDataHolder;
        }

        public PlayerStatisticsModel Model => _playerDataHolder.PlayerStatisticsModel;
        
        public void Save() => _playerDataProvider.Save(_playerDataHolder.PlayerStatisticsModel);
        public void Load() => _playerDataHolder.PlayerStatisticsModel = _playerDataProvider.Load();
    }
}