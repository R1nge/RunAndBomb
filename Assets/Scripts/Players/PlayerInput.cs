using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class PlayerInputs : MonoBehaviour
    {
        private PlayerInput _input;
        private InputAction _move;

        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _input.actions.Enable();
            _move = _input.actions.FindActionMap("Player").FindAction("Move");
        }

        public Vector2 MovementDirection => _move.ReadValue<Vector2>();

        private void OnDestroy() => _input.actions.Disable();
    }
}