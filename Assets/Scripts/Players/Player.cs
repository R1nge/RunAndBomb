using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;
        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerHealth = GetComponent<PlayerHealth>();
            _playerHealth.PlayerHasDied += PlayerHasDied;
        }

        private void Start()
        {
            ThrowBomb();
        }

        private void ThrowBomb() => _playerAnimator.PlayThrowBombAnimation();

        private void PlayerHasDied(bool isDead) => _playerAnimator.SetDeathState(isDead);

        private void Update()
        {
            _playerMovement.SendInput(_playerInputs.MovementDirection);
            _playerAnimator.PlayWalkingAnimation(_playerMovement.CurrentSpeed);
        }

        private void OnDestroy() => _playerHealth.PlayerHasDied -= PlayerHasDied;
    }
}