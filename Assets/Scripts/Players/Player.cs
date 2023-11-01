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
        private ThrowTimerUI _throwTimerUI;

        private PlayerState _currentState;

        private enum PlayerState
        {
            Idle,
            Alive,
            Dead,
            Win
        }

        public void SetNickName(string name) => _nicknameUI.SetNickname(name);

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
            _throwTimerUI = GetComponent<ThrowTimerUI>();

            Idle();

            _cameraService.SetMainCamera(win);
            _cameraService.SetPlayerCamera(player);
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
                        _trajectoryPredictor.SetTrajectoryVisible(_bombController.CanThrow);
                        _trajectoryPredictor.SetHitMarkerVisible(_bombController.CanThrow);
                        _bombController.Process();
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
            if (_currentState is PlayerState.Dead or PlayerState.Win) return;

            _currentState = PlayerState.Dead;

            _trajectoryPredictor.SetTrajectoryVisible(false);
            _trajectoryPredictor.SetHitMarkerVisible(false);
            _nicknameUI.Hide();
            _throwTimerUI.Hide();
            _colliderController.DisableCharacterColliders();
            _ragdollController.EnableRagdoll();
            _deathSound.PlayDeathSound();
            _stateMachine.ChangeState(GameStateType.Lose);
        }

        public void Idle()
        {
            _currentState = PlayerState.Idle;

            _nicknameUI.Hide();
            _throwTimerUI.Hide();
        }

        public void Alive()
        {
            _currentState = PlayerState.Alive;

            _nicknameUI.Show();
        }

        public void Win()
        {
            _currentState = PlayerState.Win;

            _playerAnimator.PlayDanceAnimation();
            _trajectoryPredictor.SetTrajectoryVisible(false);
            _trajectoryPredictor.SetHitMarkerVisible(false);
            _nicknameUI.Hide();
            _throwTimerUI.Hide();
        }

        private void OnDestroy() => _playerInputs.OnJoystickReleased -= JoystickReleased;
    }
}