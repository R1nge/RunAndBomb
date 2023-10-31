using Data;

namespace Services.Data.Player
{
    public class PlayerDataService : IPlayerDataService
    {
        private readonly IPlayerDataProvider _playerDataProvider;
        private PlayerStatisticsModel _model;

        public PlayerDataService(IPlayerDataProvider playerDataProvider) => _playerDataProvider = playerDataProvider;

        public PlayerStatisticsModel Model => _model;
        
        public void Save() => _playerDataProvider.Save(_model);
        public void Load() => _model = _playerDataProvider.Load();
    }
}