using Services.Data;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly UIService _uiService;
        private readonly CameraService _cameraService;
        private readonly PlayerAnimatorService _playerAnimatorService;

        public WinGameState(IPlayerDataService playerDataService, UIService uiService, CameraService cameraService, PlayerAnimatorService playerAnimatorService)
        {
            _playerDataService = playerDataService;
            _uiService = uiService;
            _cameraService = cameraService;
            _playerAnimatorService = playerAnimatorService;
        }

        public void Enter()
        {
            _cameraService.SwitchToWin();
            _playerAnimatorService.PlayDanceAnimation();
            _playerDataService.Model.Level++;
            _playerDataService.Save();
            _uiService.ShowWinScreen();
        }

        public void Exit() { }
    }
}