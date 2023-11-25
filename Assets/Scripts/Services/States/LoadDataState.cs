using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Data;
using Services.Data.Player;
using Services.Data.Settings;
using UnityEngine;

namespace Services.States
{
    public class LoadDataState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly LoadingService _loadingService;
        

        public LoadDataState(StateMachine stateMachine, LoadingService loadingService)
        {
            _stateMachine = stateMachine;
            _loadingService = loadingService;
        }

        public async void Enter()
        {
            await _loadingService.Load();
            _stateMachine.ChangeState(GameStateType.Reset);
        }

        public void Exit() { }
    }
}