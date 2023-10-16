using System.Collections.Generic;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly IPlayerDataProvider _playerDataProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly StateMachine _stateMachine;

        public LoadDataState(IPlayerDataProvider playerDataProvider, PlayerDataHolder playerDataHolder, StateMachine stateMachine)
        {
            _playerDataProvider = playerDataProvider;
            _playerDataHolder = playerDataHolder;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var loadings = new List<ILoadingOperation>
            {
                new DataLoadingOperation(_playerDataProvider, _playerDataHolder)
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