namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly MapGenerator _mapGenerator;
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;

        public InitGameState(MapGenerator mapGenerator, PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            _mapGenerator = mapGenerator;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public void Enter()
        {
            _mapGenerator.Generate();
            _playerFactory.Create();
            _enemyFactory.Create();
        }

        public void Exit()
        {
        }
    }
}