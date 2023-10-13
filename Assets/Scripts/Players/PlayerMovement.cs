using Data;
using UnityEngine;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private Transform model;
        private CharacterController _characterController;
        private Vector3 _moveDirection;

        public float CurrentSpeed => (Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.z)) * playerConfig.Speed;

        private void Awake() => _characterController = GetComponent<CharacterController>();

        private void Update()
        {
            Rotate();
            Gravity();
            Move();
        }

        public void SendInput(Vector2 input)
        {
            var forward = transform.TransformDirection(Vector3.forward);
            var right = transform.TransformDirection(Vector3.right);
            _moveDirection = input.x * right + input.y * forward;
        }

        private void Gravity() => _moveDirection += Vector3.down * playerConfig.Gravity;

        private void Rotate()
        {
            if (_moveDirection == Vector3.zero) return;
            model.transform.rotation = Quaternion.LookRotation(_moveDirection);
        }

        private void Move()
        {
            var motion = _moveDirection * (playerConfig.Speed * Time.deltaTime);
            _characterController.Move(motion);
        }
    }
}