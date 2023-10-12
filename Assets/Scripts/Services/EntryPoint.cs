using Data;
using Enemies;
using Players;
using Services.States;
using UnityEngine;
using VContainer;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Player player;
        [SerializeField] private Enemy enemy;
        [SerializeField] private GeneratorConfig generatorConfig;
        private IObjectResolver _objectResolver;
        private EnemyCounter _enemyCounter;
        private PlayerFactory _playerFactory;
        private EnemyFactory _enemyFactory;
        private MapGenerator _mapGenerator;
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(IObjectResolver objectResolver, StateMachine stateMachine, EnemyCounter enemyCounter)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
            _enemyCounter = enemyCounter;
        }

        public void Start()
        {
            _mapGenerator = new MapGenerator(_objectResolver, generatorConfig);

            CreateFactories();
            InitStateMachine();

            _stateMachine.ChangeState(StateType.Init);
        }

        private void CreateFactories()
        {
            _playerFactory = new PlayerFactory(_objectResolver, player, spawnPoint.position);
            _enemyFactory = new EnemyFactory(_objectResolver, enemy, _enemyCounter);
        }

        private void InitStateMachine()
        {
            _stateMachine = new StateMachine();

            _stateMachine.AddState(StateType.Init, new InitState(_mapGenerator, _playerFactory, _enemyFactory));
            _stateMachine.AddState(StateType.Game, new GameState());
            _stateMachine.AddState(StateType.Lose, new LoseState());
            _stateMachine.AddState(StateType.Win, new WinState());
        }
    }
}