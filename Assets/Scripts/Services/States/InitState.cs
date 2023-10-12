namespace Services.States
{
    public class InitState : IState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly MapGenerator _mapGenerator;

        public InitState(PlayerFactory playerFactory, MapGenerator mapGenerator)
        {
            _playerFactory = playerFactory;
            _mapGenerator = mapGenerator;
        }
        
        public void Enter()
        {
            _mapGenerator.Generate();
            _playerFactory.Spawn();
        }

        public void Exit()
        {
        }
    }
}