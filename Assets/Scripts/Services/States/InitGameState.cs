namespace Services.States
{
    public class InitGameState : IGameState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly UIService _uiService;

        public InitGameState(PlayerFactory playerFactory, UIService uiService)
        {
            _playerFactory = playerFactory;
            _uiService = uiService;
        }

        public void Enter()
        {
            _playerFactory.Create();
            _uiService.ShowStartScreen();
        }

        public void Exit() { }
    }
}