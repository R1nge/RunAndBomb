using Services.Factories;
using Services.Maps;

namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;
        private readonly UIService _uiService;
        private readonly MapGenerator _mapGenerator;
        private readonly MapDestructor _mapDestructor;
        private readonly CoroutineRunner _coroutineRunner;

        public GameState(PlayerFactory playerFactory, EnemyFactory enemyFactory, UIService uiService, MapGenerator mapGenerator, MapDestructor mapDestructor, CoroutineRunner coroutineRunner)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _uiService = uiService;
            _mapGenerator = mapGenerator;
            _mapDestructor = mapDestructor;
            _coroutineRunner = coroutineRunner;
        }

        public async void Enter()
        {
            //TODO: create player controls
            _mapGenerator.Generate();
            await _playerFactory.Create();
            await _uiService.ShowGameScreen();
            
            _enemyFactory.Create();

            _coroutineRunner.StartCoroutine(_mapDestructor.Destroy());
        }

        public void Exit() { }
    }
}