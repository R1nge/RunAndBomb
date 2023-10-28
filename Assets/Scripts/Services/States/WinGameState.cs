using Services.Data;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly UIService _uiService;
        private readonly CameraService _cameraService;

        public WinGameState(IPlayerDataService playerDataService, UIService uiService, CameraService cameraService)
        {
            _playerDataService = playerDataService;
            _uiService = uiService;
            _cameraService = cameraService;
        }

        public void Enter()
        {
            _cameraService.SwitchToWin();
            _playerDataService.Model.Level++;
            _playerDataService.Save();
            _uiService.ShowWinScreen();
        }

        public void Exit() { }
    }
}