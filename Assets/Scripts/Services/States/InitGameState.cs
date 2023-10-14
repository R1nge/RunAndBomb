namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;

        public InitGameState(PlayerFactory playerFactory) => _playerFactory = playerFactory;

        public void Enter() => _playerFactory.Create();

        public void Exit() { }
    }
}