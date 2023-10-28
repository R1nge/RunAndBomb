using Players;
using Services.Factories;
using Services.Maps;

namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;
        private readonly UIService _uiService;
        private readonly MapService _mapService;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly InputService _inputService;
        private readonly CameraService _cameraService;

        public GameState(PlayerFactory playerFactory, EnemyFactory enemyFactory, UIService uiService, MapService mapService, CoroutineRunner coroutineRunner, InputService inputService, CameraService cameraService)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _uiService = uiService;
            _mapService = mapService;
            _coroutineRunner = coroutineRunner;
            _inputService = inputService;
            _cameraService = cameraService;
        }

        public async void Enter()
        {
            _mapService.Generate();
            await _playerFactory.Create();
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