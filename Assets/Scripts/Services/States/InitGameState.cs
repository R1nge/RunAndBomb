using Services.Data;
using Services.Factories;
using Services.Maps;
using UnityEngine;

namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly UIService _uiService;
        private readonly IPlayerDataService _playerDataService;
        private readonly CameraService _cameraService;
        private readonly MapService _mapService;
        private readonly PlayerFactory _playerFactory;
        private readonly SpawnPositionsProvider _spawnPositionsProvider;
        private readonly ConfigProvider _configProvider;
        private readonly PlayerReferenceHolder _playerReferenceHolder;

        public InitGameState(UIService uiService, IPlayerDataService playerDataService, CameraService cameraService, MapService mapService, PlayerFactory playerFactory, SpawnPositionsProvider spawnPositionsProvider, ConfigProvider configProvider, PlayerReferenceHolder playerReferenceHolder)
        {
            _uiService = uiService;
            _playerDataService = playerDataService;
            _cameraService = cameraService;
            _mapService = mapService;
            _playerFactory = playerFactory;
            _spawnPositionsProvider = spawnPositionsProvider;
            _configProvider = configProvider;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public async void Enter()
        {
            _spawnPositionsProvider.CreateSpawnPoints(_configProvider.MapConfig.SpawnPositionsAmount, new Vector3(0,2,0), _configProvider.MapConfig.SpawnRadius);
            await _playerFactory.Create();
            _playerReferenceHolder.Player.Idle();
            _cameraService.SwitchToMain();
            _mapService.Generate();
            await _uiService.ShowStartScreen();
        }

        public void Exit() => _playerDataService.Save();
    }
}