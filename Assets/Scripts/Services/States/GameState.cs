namespace Services.States
{
    public class GameState : IGameState
    {
        private readonly EnemyFactory _enemyFactory;

        public GameState(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Enter()
        {
            _enemyFactory.Create();
        }

        public void Exit() { }
    }
}