using Services.Data;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly UIService _uiService;

        public WinGameState(IPlayerDataService playerDataService, UIService uiService)
        {
            _playerDataService = playerDataService;
            _uiService = uiService;
        }

        public void Enter()
        {
            //TODO: Delete player controls
            _playerDataService.Model.Level++;
            _playerDataService.Save();
            _uiService.ShowWinScreen();
        }

        public void Exit() { }
    }
}