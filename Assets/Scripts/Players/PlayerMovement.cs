using Services.Data;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform model;
        private ConfigProvider _configProvider;
        private CharacterController _characterController;
        private Vector3 _moveDirection;

        public float CurrentSpeed => _moveDirection.magnitude * _configProvider.PlayerConfig.Speed;

        [Inject]
        private void Inject(ConfigProvider configProvider) => _configProvider = configProvider;

        private void Awake() => _characterController = GetComponent<CharacterController>();

        private void Update()
        {
            Rotate();
            Gravity();
            Move();
        }

        public void SendInput(Vector2 input)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            _moveDirection = input.x * right + input.y * forward;
        }

        private void Gravity() => _moveDirection += Vector3.down * _configProvider.PlayerConfig.Gravity;

        private void Rotate()
        {
            if (_moveDirection == Vector3.zero) return;
            model.transform.rotation = Quaternion.LookRotation(_moveDirection);
        }

        private void Move()
        {
            Vector3 motion = _moveDirection * (_configProvider.PlayerConfig.Speed * Time.deltaTime);
            _characterController.Move(motion);
        }
    }
}