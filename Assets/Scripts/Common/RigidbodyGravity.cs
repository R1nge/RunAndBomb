using Bombs;
using UnityEngine;

namespace Common
{
    public class RigidbodyGravity : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        private BombProperties _bombProperties;

        public void SetBombProperties(BombProperties bombProperties) => _bombProperties = bombProperties;

        private void Awake() => rigidbody.useGravity = false;

        private void FixedUpdate() => rigidbody.AddForce(_bombProperties.Gravity);
    }
}