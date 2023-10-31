using Common;
using Players;
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
        private Collider _bombCollider;
        private SizeController _owner;
        private Rigidbody _rigidbody;
        private Collider[] _colliders;
        private bool _exploded;
        private SoundService _soundService;
        private ExplosionVFXPool _explosionVFXPool;
        private KillService _killService;
        private bool _isPlayer;

        [Inject]
        private void Inject(SoundService soundService, ExplosionVFXPool explosionVFXPool, KillService killService)
        {
            _soundService = soundService;
            _explosionVFXPool = explosionVFXPool;
            _killService = killService;
        }

        private void Awake()
        {
            _bombCollider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = new Collider[6];
        }

        public void Throw(Vector3 force, SizeController owner, bool isPlayer)
        {
            _owner = owner;
            _isPlayer = isPlayer;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other) => Explode();

        private void Explode()
        {
            if (_exploded) return;
            _exploded = true;

            _bombCollider.enabled = false;

            int hits = Physics.OverlapSphereNonAlloc(transform.position, radius * _owner.CurrentSize, _colliders, layerMask: ~ignore);

            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].TryGetComponent(out IDamageable damageable))
                {
                    if (_colliders[i].TryGetComponent(out BombController bombController))
                    {
                        if (_owner.gameObject == _colliders[i].transform.root.gameObject)
                        {
                            continue;
                        }
                        
                        if (_isPlayer)
                        {
                            _killService.Kill();
                        }
                        
                        damageable.TakeDamage();
                        
                        _owner.IncreaseSize();
                    }
                }
            }

            _soundService.PlayExplosionSound(explosionSource);

            GameObject explosionVFX = _explosionVFXPool.Get();

            explosionVFX.transform.localScale = new Vector3(_owner.CurrentSize,_owner.CurrentSize,_owner.CurrentSize);

            explosionVFX.transform.position = transform.position;
            
            meshRenderer.enabled = false;

            _rigidbody.isKinematic = true;

            if (explosionSource.clip != null)
            {
                Destroy(gameObject, explosionSource.clip.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, _owner.CurrentSize * radius);
        }
    }
}