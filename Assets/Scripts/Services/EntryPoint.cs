using Services.States;
using UnityEngine;
using VContainer;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private PlayerPrefsPlayerDataProvider _playerDataProvider;
        private PlayerDataHolder _playerDataHolder;
        private PlayerFactory _playerFactory;
        private UIService _uiService;
        private EnemyFactory _enemyFactory;
        
        [Inject]
        private void Inject(StateMachine stateMachine, PlayerPrefsPlayerDataProvider playerPrefsPlayerDataProvider, PlayerDataHolder playerDataHolder, PlayerFactory playerFactory, UIService uiService, EnemyFactory enemyFactory)
        {
            _stateMachine = stateMachine;
            _playerDataProvider = playerPrefsPlayerDataProvider;
            _playerDataHolder = playerDataHolder;
            _playerFactory = playerFactory;
            _uiService = uiService;
            _enemyFactory = enemyFactory;
        }
        
        private void Start()
        {
            InitStateMachine();

            _stateMachine.ChangeState(GameStateType.PreInit);
        }

        private void InitStateMachine()
        {
            _stateMachine.AddState(GameStateType.PreInit, new PreInit(_playerDataProvider, _playerDataHolder, _stateMachine));
            _stateMachine.AddState(GameStateType.Init, new InitGameState(_playerFactory, _uiService));
            _stateMachine.AddState(GameStateType.Game, new GameState(_enemyFactory, _uiService));
            _stateMachine.AddState(GameStateType.Lose, new LoseGameState(_uiService));
            _stateMachine.AddState(GameStateType.Win, new WinGameState(_playerDataProvider, _playerDataHolder.PlayerStatisticsModel, _uiService));
        }
    }
}