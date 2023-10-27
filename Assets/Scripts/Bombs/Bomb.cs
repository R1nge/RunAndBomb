using Services;
using UnityEngine;
using Zenject;

namespace Bombs
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private AudioSource explosionSource;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private LayerMask ignore;
        [SerializeField] private float radius;
        private int _owner;
        private Rigidbody _rigidbody;
        private Collider[] _colliders;

        private float _startTime, _endTime;

        private SoundService _soundService;
        
        [Inject]
        private void Inject(SoundService soundService) => _soundService = soundService;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = new Collider[6];
            _startTime = Time.time;
        }

        public void SetOwner(int owner) => _owner = owner;

        public void Throw(Vector3 force) => _rigidbody.AddForce(force, ForceMode.Impulse);

        private void OnTriggerEnter(Collider other) => Explode();

        private void Explode()
        {
            _endTime = Time.time;
            
            //print($"Total time {_endTime - _startTime}");
            
            int hits = Physics.OverlapSphereNonAlloc(transform.position, radius, _colliders, layerMask: ~ignore);

            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].TryGetComponent(out IDamageable damageable))
                {
                    if (_colliders[i].TryGetComponent(out BombController bombController))
                    {
                        if (_owner == _colliders[i].transform.root.gameObject.GetInstanceID())
                        {
                            continue;
                        }

                        damageable.TakeDamage();
                    }
                }
            }
            
            _soundService.PlayExplosionSound(explosionSource);

            meshRenderer.enabled = false;
            
            Destroy(gameObject, explosionSource.clip.length);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}