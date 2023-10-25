using UnityEngine;

namespace Bombs
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        private GameObject _owner;
        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void SetOwner(GameObject owner) => _owner = owner;

        public void Throw(Vector3 force) => _rigidbody.AddForce(force, ForceMode.Impulse);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                if (other.TryGetComponent(out BombController bombController))
                {
                    if (_owner == other.gameObject)
                    {
                        return;
                    }

                    damageable.TakeDamage();
                }
            }
        }
    }
}