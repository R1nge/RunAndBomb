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

        public GameState(PlayerFactory playerFactory, EnemyFactory enemyFactory, UIService uiService, MapService mapService, CoroutineRunner coroutineRunner, InputService inputService)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _uiService = uiService;
            _mapService = mapService;
            _coroutineRunner = coroutineRunner;
            _inputService = inputService;
        }

        public async void Enter()
        {
            _mapService.Generate();
            await _playerFactory.Create();
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