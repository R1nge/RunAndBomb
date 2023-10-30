using System;
using Common;
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
        private Collider _bombCollider;
        private SizeController _owner;
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
            _bombCollider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = new Collider[6];
        }

        public void Throw(Vector3 force, SizeController owner)
        {
            _owner = owner;
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

                        damageable.TakeDamage();
                        
                        _owner.GetComponent<SizeController>().IncreaseSize();
                    }
                }
            }

            _soundService.PlayExplosionSound(explosionSource);

            GameObject explosionVFX = _explosionVFXFactory.Create();

            explosionVFX.transform.localScale = new Vector3(_owner.CurrentSize,_owner.CurrentSize,_owner.CurrentSize);

            explosionVFX.transform.position = transform.position;
            
            meshRenderer.enabled = false;
            
            Destroy(gameObject, explosionSource.clip.length);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, _owner.CurrentSize * radius);
        }
    }
}