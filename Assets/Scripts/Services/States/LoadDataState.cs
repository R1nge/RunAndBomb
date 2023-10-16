using System.Collections.Generic;
using Services.Data;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly IPlayerDataService _playerDataService;
        private readonly StateMachine _stateMachine;

        public LoadDataState(IPlayerDataService playerDataService, StateMachine stateMachine)
        {
            _playerDataService = playerDataService;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var loadings = new List<ILoadingOperation>
            {
                new DataLoadingOperation(_playerDataService)
            };

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
            }

            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}