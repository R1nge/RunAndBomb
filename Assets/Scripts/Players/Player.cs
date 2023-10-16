using Bombs;
using Services.States;
using UnityEngine;
using Zenject;

namespace Players
{
    public class Player : MonoBehaviour, IDamageable
    {
        private StateMachine _stateMachine;
        private PlayerInputs _playerInputs;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;
        private BombController _bombController;
        private bool _isDead;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _playerInputs.OnJoystickReleased += JoystickReleased;
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _bombController = GetComponent<BombController>();
        }

        //TODO: create a state machine???
        
        private void Update()
        {
            if (_isDead)
            {
                return;
            }

            _playerMovement.SendInput(_playerInputs.MovementDirection);
            _playerAnimator.PlayWalkingAnimation(_playerMovement.CurrentSpeed);
        }

        private void JoystickReleased(Vector2 input) => ThrowBomb(input.magnitude);

        private void ThrowBomb(float multiplier)
        {
            if (_bombController.TryThrow(multiplier))
            {
                _playerAnimator.PlayThrowBombAnimation();
            }
        }

        public void TakeDamage()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;

            _stateMachine.ChangeState(GameStateType.Lose);
        }

        private void OnDestroy() => _playerInputs.OnJoystickReleased -= JoystickReleased;
    }
}