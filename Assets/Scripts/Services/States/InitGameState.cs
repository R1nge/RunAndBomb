using Services.Data;

namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly UIService _uiService;
        private readonly IPlayerDataService _playerDataService;
        private readonly CameraService _cameraService;

        public InitGameState(UIService uiService, IPlayerDataService playerDataService, CameraService cameraService)
        {
            _uiService = uiService;
            _playerDataService = playerDataService;
            _cameraService = cameraService;
        }

        public async void Enter()
        {
            _cameraService.SwitchToMain();
            await _uiService.ShowStartScreen();
        }

        public void Exit() => _playerDataService.Save();
    }
}