using System.Collections.Generic;
using UnityEngine;

namespace Services.States
{
    public class PreInit : IGameState
    {
        private readonly PlayerPrefsPlayerDataProvider _playerDataProvider;
        private readonly PlayerDataHolder _playerDataHolder;
        private readonly StateMachine _stateMachine;

        public PreInit(PlayerPrefsPlayerDataProvider playerPrefsPlayerDataProvider, PlayerDataHolder playerDataHolder,
            StateMachine stateMachine)
        {
            _playerDataProvider = playerPrefsPlayerDataProvider;
            _playerDataHolder = playerDataHolder;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var loadings = new List<ILoadingOperation>
            {
                new PlayerPrefsDataLoadingOperation(_playerDataProvider, _playerDataHolder)
            };

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
            }

            Debug.Log("Changed state");
            _stateMachine.ChangeState(GameStateType.Init);
        }

        public void Exit() { }
    }
}