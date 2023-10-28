using System.Collections.Generic;
using Players;
using Services.Assets;
using Services.Data;
using Services.Factories;
using Services.Maps;
using UnityEngine;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states;
        private IGameState _currentGameState;

        public StateMachine(IPlayerDataService playerDataService, CoroutineRunner coroutineRunner, UIService uiService, PlayerFactory playerFactory, EnemyFactory enemyFactory, MapService mapService, RestartService restartService, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider, InputService inputService)
        {
            _states = new Dictionary<GameStateType, IGameState>
            {
                { GameStateType.PreWarm, new PreWarmState(this, loadingScreenAssetProvider, startScreenAssetProvider) },
                { GameStateType.LoadData, new LoadDataState(this, playerDataService, uiService) },
                { GameStateType.Reset, new ResetState(this, coroutineRunner, restartService, mapService) },
                { GameStateType.Init, new InitGameState(uiService, playerDataService) },
                { GameStateType.Game, new GameState(playerFactory, enemyFactory, uiService, mapService, coroutineRunner, inputService) },
                { GameStateType.Win, new WinGameState(playerDataService, uiService) },
                { GameStateType.Lose, new LoseGameState(uiService) }
            };
        }

        public void ChangeState(GameStateType gameStateType)
        {
            if (gameStateType is GameStateType.Win or GameStateType.Lose)
            {
                if (_currentGameState == _states[GameStateType.Win] || _currentGameState == _states[GameStateType.Lose])
                {
                    Debug.LogError($"Trying to switch to {gameStateType} while already in {_currentGameState}");
                    return;
                }
            }
            
            _currentGameState?.Exit();
            _currentGameState = _states[gameStateType];
            _currentGameState.Enter();
        }
    }
}