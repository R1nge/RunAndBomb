namespace Services
{
    public class PlayerPrefsDataLoadingOperation : ILoadingOperation
    {
        private readonly PlayerPrefsPlayerDataProvider _playerPrefsPlayerDataProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        
        public PlayerPrefsDataLoadingOperation(PlayerPrefsPlayerDataProvider playerDataProvider, PlayerDataHolder playerDataHolder)
        {
            _playerPrefsPlayerDataProvider = playerDataProvider;
            _playerDataHolder = playerDataHolder;
        }

        public void Load() => _playerDataHolder.PlayerStatisticsModel = _playerPrefsPlayerDataProvider.Load();
    }
}