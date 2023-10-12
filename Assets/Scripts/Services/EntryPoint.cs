using Services.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class EntryPoint : MonoBehaviour, IStartable
    {
        [SerializeField] private Player.Player player;
        private IObjectResolver _objectResolver;
        private PlayerSpawner _playerSpawner;
        private StateMachine _stateMachine;

        [Inject]
        private void Inject(IObjectResolver objectResolver, StateMachine stateMachine)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
        }

        public void Start()
        {
            _playerSpawner = new PlayerSpawner(_objectResolver, player);
            _stateMachine.AddState(new InitState(_playerSpawner));

            _stateMachine.ChangeState();
        }
    }
}