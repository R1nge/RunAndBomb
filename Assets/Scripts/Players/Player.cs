using System.Collections;
using Bombs;
using Common;
using Services.States;
using UIs;
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
        private TrajectoryPredictor _trajectoryPredictor;
        private RagdollController _ragdollController;
        private ColliderController _colliderController;
        private NicknameUI _nicknameUI;
        private DeathSound _deathSound;
        private bool _isDead;

        [Inject]
        private void Inject(StateMachine stateMachine) => _stateMachine = stateMachine;

        //TODO: create a state machine
        
        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _playerInputs.OnJoystickReleased += JoystickReleased;
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _bombController = GetComponent<BombController>();
            _trajectoryPredictor = GetComponent<TrajectoryPredictor>();
            
            _ragdollController = GetComponent<RagdollController>();
            _colliderController = GetComponent<ColliderController>();
            _nicknameUI = GetComponent<NicknameUI>();
            _deathSound = GetComponent<DeathSound>();
        }

        private void Update()
        {
            if (_isDead)
            {
                return;
            }

            _playerMovement.SendInput(_playerInputs.MovementDirection);
            _playerAnimator.PlayWalkingAnimation(_playerMovement.CurrentSpeed);
            _bombController.SetMultiplier(_playerMovement.CurrentSpeed);
            _playerMovement.ProcessMovement();

            _trajectoryPredictor.SetTrajectoryVisible(_bombController.CanThrow);
        }

        private void JoystickReleased(Vector2 input) => ThrowBomb();

        private void ThrowBomb()
        {
            if (_bombController.TryThrow())
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
            _trajectoryPredictor.SetTrajectoryVisible(false);
            _nicknameUI.Hide();
            _colliderController.DisableCharacterColliders();
            _ragdollController.EnableRagdoll();
            _deathSound.PlayDeathSound();
            _stateMachine.ChangeState(GameStateType.Lose);
        }

        private void OnDestroy() => _playerInputs.OnJoystickReleased -= JoystickReleased;
    }
}