using System;
using Enemies;
using UnityEngine;

namespace Services.Maps
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform detectTransform;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ignore;
        private readonly Collider[] _colliders = new Collider[4];
        
        public void Drop()
        {
            int hits = Physics.OverlapSphereNonAlloc(detectTransform.position, radius, _colliders, layerMask: ~ignore);

            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].TryGetComponent(out Enemy enemy))
                {
                    enemy.Fall();
                }
            }
            
            Destroy(gameObject);
        }
    }
}