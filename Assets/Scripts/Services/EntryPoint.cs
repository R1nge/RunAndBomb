using System.Collections;
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
        private IObjectResolver _objectResolver;
        private StateMachine _stateMachine;
        private PlayerFactory _playerFactory;
        private EnemySkinService _enemySkinService;
        private EnemyCounter _enemyCounter;
        private EnemyFactory _enemyFactory;
        private IPlayerDataProvider _playerDataProvider;
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
            _playerDataHolder = new PlayerDataHolder(_playerDataProvider.Load());
            
            print($"[DATA] Level: {_playerDataHolder.PlayerStatisticsModel.Level}");
            print($"[DATA] Name: {_playerDataHolder.PlayerStatisticsModel.Name}");

            _enemySkinService = new EnemySkinService(enemySkins);

            CreateFactories();
            InitStateMachine();

            _stateMachine.ChangeState(GameStateType.Init);

            StartCoroutine(StartNext());
        }

        private IEnumerator StartNext()
        {
            yield return new WaitForSeconds(3);
            _stateMachine.ChangeState(GameStateType.Game);
        }

        private void CreateFactories()
        {
            _playerFactory = new PlayerFactory(_objectResolver, player, spawnPoints[0].position, _playerDataHolder);
            _enemyFactory = new EnemyFactory(_objectResolver, _enemySkinService, _enemyCounter, spawnPoints);
        }

        private void InitStateMachine()
        {
            _stateMachine.AddState(GameStateType.Init, new InitGameState(_playerFactory));
            _stateMachine.AddState(GameStateType.Game, new GameState( _enemyFactory));
            _stateMachine.AddState(GameStateType.Lose, new LoseGameState());
            _stateMachine.AddState(GameStateType.Win, new WinGameState(_playerDataProvider, _playerDataHolder.PlayerStatisticsModel));
        }
    }
}