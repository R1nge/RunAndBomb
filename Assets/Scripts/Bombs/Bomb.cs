using UnityEngine;

namespace Bombs
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        private sbyte _owner;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetOwner(sbyte owner)
        {
            _owner = owner;
        }

        public void Throw(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                if (other.TryGetComponent(out BombController bombController))
                {
                    if (bombController.OwnerId != _owner)
                    {
                        damageable.Damage();
                    }
                }
                else
                {
                    damageable.Damage();
                }
            }
        }
    }
}