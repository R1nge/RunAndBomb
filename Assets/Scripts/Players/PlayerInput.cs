using System;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        private InputService _inputService;
        
        [Inject]
        private void Inject(InputService inputService) => _inputService = inputService;

        private void Awake()
        {
            _inputService.OnInputEnableStateChanged += InputStateChanged;
            joystick.OnJoystickReleased += JoystickReleased;
        }

        private void InputStateChanged(bool isEnabled) => joystick.enabled = isEnabled;

        private void JoystickReleased(Vector2 direction)
        {
            if (_inputService.InputEnabled)
            {
                OnJoystickReleased?.Invoke(direction);
            }
        }

        public event Action<Vector2> OnJoystickReleased;

        public Vector2 MovementDirection => _inputService.InputEnabled ? joystick.Direction : Vector2.zero;

        private void OnDestroy()
        {
            _inputService.OnInputEnableStateChanged -= InputStateChanged;
            joystick.OnJoystickReleased -= JoystickReleased;
        }
    }
}