using UnityEngine;

namespace Players
{
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;

        public Joystick Joystick => joystick;

        public Vector2 MovementDirection => joystick.Direction;
    }
}