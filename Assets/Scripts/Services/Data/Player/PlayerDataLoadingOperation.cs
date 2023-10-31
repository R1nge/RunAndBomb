namespace Services.Data.Player
{
    public class PlayerDataLoadingOperation : ILoadingOperation
    {
        private readonly IPlayerDataService _playerDataService;
        
        public PlayerDataLoadingOperation(IPlayerDataService playerDataService) => _playerDataService = playerDataService;

        public void Load() => _playerDataService.Load();
    }
}