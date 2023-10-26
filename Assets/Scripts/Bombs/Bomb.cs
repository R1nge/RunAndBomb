using UnityEngine;

namespace Bombs
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private LayerMask ignore;
        [SerializeField] private float radius;
        private GameObject _owner;
        private Rigidbody _rigidbody;
        private Collider[] _colliders;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = new Collider[6];
        }

        public void SetOwner(GameObject owner) => _owner = owner;

        public void Throw(Vector3 force) => _rigidbody.AddForce(force, ForceMode.Impulse);

        private void OnTriggerEnter(Collider other) => Explode(other.gameObject);

        private void Explode(GameObject other)
        {
            int hits = Physics.OverlapSphereNonAlloc(transform.position, radius, _colliders, layerMask: ~ignore);

            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].TryGetComponent(out IDamageable damageable))
                {
                    if (_colliders[i].TryGetComponent(out BombController bombController))
                    {
                        if (_owner == other)
                        {
                            return;
                        }

                        damageable.TakeDamage();
                    }
                }
            }
        }
    }
}