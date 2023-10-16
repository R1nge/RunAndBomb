namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly UIService _uiService;
        private readonly IPlayerDataService _playerDataService;

        public InitGameState( UIService uiService, IPlayerDataService playerDataService)
        {
            _uiService = uiService;
            _playerDataService = playerDataService;
        }

        public void Enter()
        {
            _uiService.ShowStartScreen();
        }

        public void Exit() => _playerDataService.Save();
    }
}