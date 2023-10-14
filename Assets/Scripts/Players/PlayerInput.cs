using System;
using UnityEngine;

namespace Players
{
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;

        private void Awake() => joystick.OnJoystickReleased += OnJoystickReleased;

        public event Action<Vector2> OnJoystickReleased;

        public Vector2 MovementDirection => joystick.Direction;

        private void OnDestroy() => joystick.OnJoystickReleased -= OnJoystickReleased;
    }
}