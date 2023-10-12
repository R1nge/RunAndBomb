using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float gravity;
        [SerializeField] private Transform model;
        private CharacterController _characterController;
        private PlayerInput _input;
        private InputAction _move;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _input = GetComponent<PlayerInput>();
            _input.actions.Enable();
            _move = _input.actions.FindActionMap("Player").FindAction("Move");
        }

        private void Update()
        {
            GetInput();
            Rotate();
            Gravity();
            Move();
        }

        private void GetInput()
        {
            var input = _move.ReadValue<Vector2>();
            var forward = transform.TransformDirection(Vector3.forward);
            var right = transform.TransformDirection(Vector3.right);
            _moveDirection = input.x * right + input.y * forward;
        }

        private void Gravity() => _moveDirection += Vector3.down * gravity;

        private void Rotate()
        {
            if (_moveDirection == Vector3.zero) return;
            model.transform.rotation = Quaternion.LookRotation(_moveDirection);
        }

        private void Move()
        {
            var motion = _moveDirection * (speed * Time.deltaTime);
            _characterController.Move(motion);
        }

        private void OnDestroy() => _input.actions.Disable();
    }
}