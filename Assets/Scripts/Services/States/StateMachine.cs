using System.Collections.Generic;
using Players;
using Services.Assets;
using Services.Data;
using Services.Data.Player;
using Services.Data.Settings;
using Services.Factories;
using Services.Maps;
using UnityEngine;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states;
        private IGameState _currentGameState;

        public StateMachine(IPlayerDataService playerDataService, ISettingsDataService settingsDataService, CoroutineRunner coroutineRunner, UIService uiService, PlayerFactory playerFactory, EnemySpawner enemySpawner, MapService mapService, RestartService restartService, LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider, InputService inputService, CameraService cameraService, PlayerReferenceHolder playerReferenceHolder, SpawnPositionsProvider spawnPositionsProvider, ConfigProvider configProvider, ExplosionVFXPool explosionVFXPool)
        {
            _states = new Dictionary<GameStateType, IGameState>
            {
                { GameStateType.PreWarm, new PreWarmState(this, loadingScreenAssetProvider, startScreenAssetProvider, explosionVFXPool) },
                { GameStateType.LoadData, new LoadDataState(this, playerDataService, settingsDataService, uiService) },
                { GameStateType.Reset, new ResetState(this, coroutineRunner, restartService, mapService) },
                { GameStateType.Init, new InitGameState(uiService, playerDataService, cameraService, mapService, playerFactory, spawnPositionsProvider, configProvider, playerReferenceHolder) },
                { GameStateType.Game, new GameState(enemySpawner, uiService, mapService, coroutineRunner, inputService, cameraService, playerReferenceHolder) },
                { GameStateType.Win, new WinGameState(playerDataService, uiService, cameraService, playerReferenceHolder) },
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