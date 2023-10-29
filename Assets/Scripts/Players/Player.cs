using Bombs;
using Cinemachine;
using Common;
using Services;
using Services.States;
using UIs;
using UnityEngine;
using Zenject;

namespace Players
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private CinemachineVirtualCamera player, win;
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
        private CameraService _cameraService;
        private InputService _inputService;

        public PlayerAnimator PlayerAnimator => _playerAnimator;

        private PlayerState _currentState;

        private enum PlayerState
        {
            Alive,
            Dead
        }

        [Inject]
        private void Inject(StateMachine stateMachine, CameraService cameraService, InputService inputService)
        {
            _stateMachine = stateMachine;
            _cameraService = cameraService;
            _inputService = inputService;
        }

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


            _cameraService.SetPlayerCamera(player);
            _cameraService.SetWinCamera(win);
        }

        private void Update()
        {
            switch (_currentState)
            {
                case PlayerState.Alive:

                    if (_inputService.InputEnabled)
                    {
                        _playerMovement.SendInput(_playerInputs.MovementDirection);
                        _playerAnimator.PlayWalkingAnimation(_playerMovement.CurrentSpeed);
                        _bombController.SetMultiplier(_playerMovement.CurrentSpeed);
                        _playerMovement.ProcessMovement();
                        _bombController.Process();
                        _trajectoryPredictor.SetTrajectoryVisible(_bombController.CanThrow);
                    }

                    break;
            }
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
            if (_currentState == PlayerState.Dead) return;

            _currentState = PlayerState.Dead;

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