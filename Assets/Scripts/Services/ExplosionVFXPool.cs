using System.Collections.Generic;
using Services.Factories;
using UnityEngine;

namespace Services
{
    public class ExplosionVFXPool
    {
        private readonly ExplosionVFXFactory _explosionVFXFactory;
        private Queue<GameObject> _pool;

        private ExplosionVFXPool(ExplosionVFXFactory explosionVFXFactory) => _explosionVFXFactory = explosionVFXFactory;

        public async void CreatePool(int amount)
        {
            if (_pool != null)
            {
                var count = _pool.Count;
                for (int i = 0; i < count; i++)
                {
                    var vfx = _pool.Dequeue();
                    vfx.SetActive(false);
                    _pool.Enqueue(vfx);
                }
            }
            
            _pool = new Queue<GameObject>(amount);

            for (int i = 0; i < amount; i++)
            {
                GameObject explosion = await _explosionVFXFactory.Create();
                explosion.SetActive(false);
                _pool.Enqueue(explosion);
            }
        }

        public GameObject Get()
        {
            if (!_pool.TryDequeue(out GameObject explosion))
            {
                Debug.LogError("All pooled explosion VFX are in use");
            }
            else
            {
                explosion.SetActive(true);
            }

            return explosion;
        }

        public void Release(GameObject explosionVFX)
        {
            explosionVFX.SetActive(false);
            _pool.Enqueue(explosionVFX);
        }
    }
}