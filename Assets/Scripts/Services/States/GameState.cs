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

        public GameState(PlayerFactory playerFactory, EnemyFactory enemyFactory, UIService uiService, MapGenerator mapGenerator)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _uiService = uiService;
            _mapGenerator = mapGenerator;
        }

        public async void Enter()
        {
            //TODO: create player controls
            _mapGenerator.Generate();
            await _playerFactory.Create();
            await _uiService.ShowGameScreen();
            
            _enemyFactory.Create();
        }

        public void Exit() { }
    }
}