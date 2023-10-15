using Services.Factories;

namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly UIService _uiService;

        public GameState(EnemyFactory enemyFactory, UIService uiService)
        {
            _enemyFactory = enemyFactory;
            _uiService = uiService;
        }

        public void Enter()
        {
            //TODO: create player controls
            _uiService.ShowGameScreen();
            _enemyFactory.Create();
        }

        public void Exit() { }
    }
}