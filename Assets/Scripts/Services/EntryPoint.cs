using System.Collections.Generic;
using Data;
using Players;
using Services.States;
using UnityEngine;
using VContainer;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Player player;
        [SerializeField] private EnemySkinsConfig enemySkins;
        [SerializeField] private UIConfig uiConfig;
        private IObjectResolver _objectResolver;
        
        private StateMachine _stateMachine;
        private UIService _uiService;
        
        private PlayerFactory _playerFactory;
        
        private EnemySkinService _enemySkinService;
        private EnemyCounter _enemyCounter;
        private EnemyFactory _enemyFactory;
        
        private StartScreenFactory _startScreenFactory;
        private GamePlayScreenFactory _gamePlayScreenFactory;
        private WinScreenFactory _winScreenFactory;
        private LoseScreenFactory _loseScreenFactory;

        private PlayerPrefsPlayerDataProvider _playerDataProvider;
        private PlayerDataHolder _playerDataHolder;

        [Inject]
        private void Inject(IObjectResolver objectResolver, StateMachine stateMachine, EnemyCounter enemyCounter)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
            _enemyCounter = enemyCounter;
        }

        public void Start()
        {
            _playerDataProvider = new PlayerPrefsPlayerDataProvider();
            _playerDataHolder = new PlayerDataHolder();

            var loadings = new List<ILoadingOperation>
            {
                new PlayerPrefsDataLoadingOperation(_playerDataProvider, _playerDataHolder)
            };

            for (int i = 0; i < loadings.Count; i++)
            {
                loadings[i].Load();
            }
            
            print($"[DATA] Level: {_playerDataHolder.PlayerStatisticsModel.Level}");
            print($"[DATA] Name: {_playerDataHolder.PlayerStatisticsModel.Name}");

            _enemySkinService = new EnemySkinService(enemySkins);

            CreateFactories();
            
            _uiService = new UIService(_startScreenFactory, _gamePlayScreenFactory, _winScreenFactory, _loseScreenFactory);
            
            InitStateMachine();

            _stateMachine.ChangeState(GameStateType.Init);
        }

        private void CreateFactories()
        {
            _playerFactory = new PlayerFactory(_objectResolver, player, spawnPoints[0].position, _playerDataHolder);
            _enemyFactory = new EnemyFactory(_objectResolver, _enemySkinService, _enemyCounter, spawnPoints);
            
            _startScreenFactory = new StartScreenFactory(_objectResolver, uiConfig.StartScreen);
            _gamePlayScreenFactory = new GamePlayScreenFactory(_objectResolver, uiConfig.GamePlayScreen);
            _winScreenFactory = new WinScreenFactory(_objectResolver, uiConfig.Win);
            _loseScreenFactory = new LoseScreenFactory(_objectResolver, uiConfig.Lose);
        }

        private void InitStateMachine()
        {
            _stateMachine.AddState(GameStateType.Init, new InitGameState(_playerFactory, _uiService));
            _stateMachine.AddState(GameStateType.Game, new GameState(_enemyFactory, _uiService));
            _stateMachine.AddState(GameStateType.Lose, new LoseGameState(_uiService));
            _stateMachine.AddState(GameStateType.Win, new WinGameState(_playerDataProvider, _playerDataHolder.PlayerStatisticsModel, _uiService));
        }
    }
}