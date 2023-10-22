namespace Services.States
{
    public class LoseGameState : IGameState
    {
        private readonly UIService _uiService;

        public LoseGameState(UIService uiService) => _uiService = uiService;

        public void Enter()
        {
            //TODO: Delete player controls
            _uiService.ShowLoseScreen();
        }

        public void Exit() { }
    }
}