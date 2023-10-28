using Services.Data;
using Services.Factories;
using Services.Maps;

namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly UIService _uiService;
        private readonly IPlayerDataService _playerDataService;
        private readonly CameraService _cameraService;
        private readonly MapService _mapService;
        private readonly PlayerFactory _playerFactory;

        public InitGameState(UIService uiService, IPlayerDataService playerDataService, CameraService cameraService, MapService mapService, PlayerFactory playerFactory)
        {
            _uiService = uiService;
            _playerDataService = playerDataService;
            _cameraService = cameraService;
            _mapService = mapService;
            _playerFactory = playerFactory;
        }

        public async void Enter()
        {
            await _playerFactory.CreateModel();
            _cameraService.SwitchToMain();
            _mapService.Generate();
            await _uiService.ShowStartScreen();
        }

        public void Exit() => _playerDataService.Save();
    }
}