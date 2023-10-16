namespace Services
{
    public class DataLoadingOperation : ILoadingOperation
    {
        private readonly IPlayerDataService _playerDataService;
        
        public DataLoadingOperation(IPlayerDataService playerDataService) => _playerDataService = playerDataService;

        public void Load() => _playerDataService.Load();
    }
}