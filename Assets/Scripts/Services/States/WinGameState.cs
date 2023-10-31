using Services.Data;
using Services.Data.Player;

namespace Services.States
{
    public class WinGameState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly UIService _uiService;
        private readonly CameraService _cameraService;
        private readonly PlayerReferenceHolder _playerReferenceHolder;
        
        public WinGameState(IPlayerDataService playerDataService, UIService uiService, CameraService cameraService, PlayerReferenceHolder playerReferenceHolder)
        {
            _playerDataService = playerDataService;
            _uiService = uiService;
            _cameraService = cameraService;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public void Enter()
        {
            _cameraService.SwitchToMain();
            _playerReferenceHolder.Player.Win();
            _playerDataService.Model.Level++;
            _playerDataService.Save();
            _uiService.ShowWinScreen();
        }

        public void Exit() { }
    }
}