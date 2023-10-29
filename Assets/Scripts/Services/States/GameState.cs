using Players;
using Services.Data;
using Services.Factories;
using Services.Maps;
using UnityEngine;

namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly UIService _uiService;
        private readonly MapService _mapService;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly InputService _inputService;
        private readonly CameraService _cameraService;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerReferenceHolder _playerReferenceHolder;

        public GameState(EnemyFactory enemyFactory, UIService uiService, MapService mapService, CoroutineRunner coroutineRunner, InputService inputService, CameraService cameraService, PlayerReferenceHolder playerReferenceHolder)
        {
            _enemyFactory = enemyFactory;
            _uiService = uiService;
            _mapService = mapService;
            _coroutineRunner = coroutineRunner;
            _inputService = inputService;
            _cameraService = cameraService;
            _playerReferenceHolder = playerReferenceHolder;
        }

        public async void Enter()
        {
            _playerReferenceHolder.Player.Alive();
            _cameraService.SwitchToPlayer();
            await _uiService.ShowGameScreen();
            _inputService.Enable();
            _enemyFactory.Create();
            _coroutineRunner.StartCoroutine(_mapService.DestroyPlatforms());
        }

        public void Exit()
        {
            _inputService.Disable();
            _coroutineRunner.StopCoroutines();
        }
    }
}