using Bombs;
using Services.States;
using UnityEngine;
using VContainer;

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
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _bombController = GetComponent<BombController>();
        }

        private void Update()
        {
            if (_isDead)
            {
                return;
            }

            _playerMovement.SendInput(_playerInputs.MovementDirection);
            _playerAnimator.PlayWalkingAnimation(_playerMovement.CurrentSpeed);
            _bombController.SetCurrentThrowForce(_playerMovement.CurrentSpeed);

            if (_playerMovement.CurrentSpeed <= 0)
            {
                ThrowBomb();
            }
        }

        private void ThrowBomb()
        {
            if (_bombController.TryThrow())
            {
                _playerAnimator.PlayThrowBombAnimation();
            }
        }

        public void Damage()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;

            _playerAnimator.SetDeathState(_isDead);
            _stateMachine.ChangeState(StateType.Lose);
        }
    }
}