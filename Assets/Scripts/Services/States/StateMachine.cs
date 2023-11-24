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

        public StateMachine(GameStatesFactory gameStatesFactory)
        {
            _states = new Dictionary<GameStateType, IGameState>
            {
                { GameStateType.PreWarm, gameStatesFactory.CreatePreWarmState(this) },
                { GameStateType.LoadData, gameStatesFactory.CreateLoadDataState(this) },
                { GameStateType.Reset, gameStatesFactory.CreateResetState(this) },
                { GameStateType.Init, gameStatesFactory.CreateInitGameState(this) },
                { GameStateType.Game, gameStatesFactory.CreateGameState(this) },
                { GameStateType.Win, gameStatesFactory.CreateWinGameState(this) },
                { GameStateType.Lose, gameStatesFactory.CreateLoseGameState(this) }
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