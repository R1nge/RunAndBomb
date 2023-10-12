using Data;
using Services.States;
using UnityEngine;
using VContainer;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Player.Player player;
        [SerializeField] private GeneratorConfig generatorConfig;
        private IObjectResolver _objectResolver;
        private Logger _logger;
        private PlayerFactory _playerFactory;
        private MapGenerator _mapGenerator;
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(IObjectResolver objectResolver, StateMachine stateMachine)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
        }

        public void Start()
        {
            _logger = new Logger();

            _playerFactory = new PlayerFactory(_objectResolver, player, spawnPoint.position);
            _mapGenerator = new MapGenerator(_objectResolver, generatorConfig);

            _stateMachine.AddState(new InitState(_playerFactory, _mapGenerator));
            _stateMachine.AddState(new GameState());

            _stateMachine.ChangeState();
        }
    }
}