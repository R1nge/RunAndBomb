namespace Services.States
{
    public class InitState : IState
    {
        private readonly PlayerSpawner _playerSpawner;
        private readonly MapGenerator _mapGenerator;

        public InitState(PlayerSpawner playerSpawner, MapGenerator mapGenerator)
        {
            _playerSpawner = playerSpawner;
            _mapGenerator = mapGenerator;
        }
        
        public void Enter()
        {
            _mapGenerator.Generate();
            _playerSpawner.Spawn();
        }

        public void Exit()
        {
        }
    }
}