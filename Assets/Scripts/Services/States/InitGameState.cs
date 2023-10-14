namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;

        public InitGameState(PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public void Enter()
        {
            _playerFactory.Create();
            _enemyFactory.Create();
        }

        public void Exit()
        {
        }
    }
}