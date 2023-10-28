using Services;
using Services.Factories;
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
        private float _size;
        private Rigidbody _rigidbody;
        private Collider[] _colliders;
        private bool _exploded;
        private SoundService _soundService;
        private ExplosionVFXFactory _explosionVFXFactory;

        [Inject]
        private void Inject(SoundService soundService, ExplosionVFXFactory explosionVFXFactory)
        {
            _soundService = soundService;
            _explosionVFXFactory = explosionVFXFactory;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = new Collider[6];
        }

        public void Throw(Vector3 force, int owner, float size)
        {
            _owner = owner;
            _size = size;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other) => Explode();

        private async void Explode()
        {
            if (_exploded) return;
            _exploded = true;

            int hits = Physics.OverlapSphereNonAlloc(transform.position, radius * _size, _colliders, layerMask: ~ignore);

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

            GameObject explosionVFX = await _explosionVFXFactory.Create();

            explosionVFX.transform.localScale = new Vector3(_size,_size,_size);

            explosionVFX.transform.position = transform.position;
            
            meshRenderer.enabled = false;
            
            Destroy(gameObject, explosionSource.clip.length);
        }
    }
}