using System.Collections.Generic;
using Services.Data;
using Services.Factories;
using Services.Maps;

namespace Services.States
{
    public class StateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states;
        private IGameState _currentGameState;

        public StateMachine(IPlayerDataService playerDataService, CoroutineRunner coroutineRunner, UIService uiService, PlayerFactory playerFactory, EnemyFactory enemyFactory, MapGenerator mapGenerator, RestartService restartService)
        {
            _states = new Dictionary<GameStateType, IGameState>
            {
                { GameStateType.LoadData, new LoadDataState(this, playerDataService, uiService) },
                { GameStateType.Reset, new ResetState(this, coroutineRunner, restartService) },
                { GameStateType.Init, new InitGameState(uiService, playerDataService) },
                { GameStateType.Game, new GameState(playerFactory, enemyFactory, uiService, mapGenerator) },
                { GameStateType.Win, new WinGameState(playerDataService, uiService) },
                { GameStateType.Lose, new LoseGameState(uiService) }
            };
        }

        public void ChangeState(GameStateType gameStateType)
        {
            _currentGameState?.Exit();
            _currentGameState = _states[gameStateType];
            _currentGameState.Enter();
        }
    }
}