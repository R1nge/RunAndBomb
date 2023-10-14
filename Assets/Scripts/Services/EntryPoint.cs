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

        [Inject]
        private void Inject(IObjectResolver objectResolver, StateMachine stateMachine, EnemyCounter enemyCounter)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
            _enemyCounter = enemyCounter;
        }

        public void Start()
        {
            _enemySkinService = new EnemySkinService(enemySkins);

            CreateFactories();
            InitStateMachine();

            _stateMachine.ChangeState(GameStateType.Init);
        }

        private void CreateFactories()
        {
            _playerFactory = new PlayerFactory(_objectResolver, player, spawnPoints[0].position);
            _enemyFactory = new EnemyFactory(_objectResolver, _enemySkinService, _enemyCounter, spawnPoints);
        }

        private void InitStateMachine()
        {
            _stateMachine.AddState(GameStateType.Init, new InitGameState(_playerFactory, _enemyFactory));
            _stateMachine.AddState(GameStateType.Game, new GameState());
            _stateMachine.AddState(GameStateType.Lose, new LoseGameState());
            _stateMachine.AddState(GameStateType.Win, new WinGameState());
        }
    }
}