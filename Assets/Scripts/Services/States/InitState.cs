namespace Services.States
{
    public class InitState : IState
    {
        private readonly MapGenerator _mapGenerator;
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;

        public InitState(MapGenerator mapGenerator, PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            _mapGenerator = mapGenerator;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public void Enter()
        {
            _mapGenerator.Generate();
            _playerFactory.Spawn();
            _enemyFactory.Spawn();
        }

        public void Exit()
        {
        }
    }
}