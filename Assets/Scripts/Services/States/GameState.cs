using Services.Factories;

namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;
        private readonly UIService _uiService;

        public GameState(PlayerFactory playerFactory, EnemyFactory enemyFactory, UIService uiService)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _uiService = uiService;
        }

        public async void Enter()
        {
            //TODO: create player controls
            await _playerFactory.Create();
            _uiService.ShowGameScreen();
            _enemyFactory.Create();
        }

        public void Exit() { }
    }
}