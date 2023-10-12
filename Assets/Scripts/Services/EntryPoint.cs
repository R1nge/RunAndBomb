using Data;
using Services.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class EntryPoint : MonoBehaviour, IStartable
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private GeneratorData generatorData;
        private IObjectResolver _objectResolver;
        private Logger _logger;
        private PlayerSpawner _playerSpawner;
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
            
            _playerSpawner = new PlayerSpawner(_objectResolver, player);
            _mapGenerator = new MapGenerator(_logger, generatorData);
            
            _stateMachine.AddState(new InitState(_playerSpawner, _mapGenerator));

            _stateMachine.ChangeState();
        }
    }
}