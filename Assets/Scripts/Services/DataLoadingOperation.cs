namespace Services
{
    public class DataLoadingOperation : ILoadingOperation
    {
        private readonly IPlayerDataProvider _playerDataProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        
        public DataLoadingOperation(IPlayerDataProvider playerDataProvider, PlayerDataHolder playerDataHolder)
        {
            _playerDataProvider = playerDataProvider;
            _playerDataHolder = playerDataHolder;
        }

        public void Load() => _playerDataHolder.PlayerStatisticsModel = _playerDataProvider.Load();
    }
}