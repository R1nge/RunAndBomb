using Services.Factories;
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
        private CoroutineRunner _coroutineRunner;
        private IPlayerDataService _playerDataService;
        
        [Inject]
        private void Inject(StateMachine stateMachine, IPlayerDataService playerDataService, PlayerFactory playerFactory, UIService uiService, EnemyFactory enemyFactory, CoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _playerDataService = playerDataService;
            _playerFactory = playerFactory;
            _uiService = uiService;
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }
        
        private void Start()
        {
            InitStateMachine();

            _stateMachine.ChangeState(GameStateType.LoadData);
        }

        private void InitStateMachine()
        {
            _stateMachine.AddState(GameStateType.LoadData, new LoadDataState(_playerDataService, _stateMachine));
            _stateMachine.AddState(GameStateType.Reset, new ResetState(_stateMachine, _coroutineRunner));
            _stateMachine.AddState(GameStateType.Init, new InitGameState(_uiService, _playerDataService));
            _stateMachine.AddState(GameStateType.Game, new GameState(_playerFactory, _enemyFactory, _uiService));
            _stateMachine.AddState(GameStateType.Lose, new LoseGameState(_uiService));
            _stateMachine.AddState(GameStateType.Win, new WinGameState(_playerDataService, _uiService));
        }
    }
}