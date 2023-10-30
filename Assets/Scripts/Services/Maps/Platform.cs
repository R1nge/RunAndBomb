using System.Collections;
using Enemies;
using UnityEngine;

namespace Services.Maps
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color lerpColor;
        [SerializeField] private Transform detectTransform;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask ignore;
        private readonly Collider[] _colliders = new Collider[4];
        private Color _startColor;
        private Vector3 _startPosition, _dropPosition;

        private void Awake() => _startColor = meshRenderer.material.color;

        public void Drop()
        {
            _startPosition = transform.position;
            _dropPosition = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            StartCoroutine(DropCoroutine());
        }

        private IEnumerator DropCoroutine()
        {
            yield return StartCoroutine(LerpColor(1, 3));
            
            int hits = Physics.OverlapSphereNonAlloc(detectTransform.position, radius, _colliders, layerMask: ~ignore);

            for (int i = 0; i < hits; i++)
            {
                if (_colliders[i].transform.root.TryGetComponent(out Enemy enemy))
                {
                    enemy.Fall();
                }
            }

            yield return StartCoroutine(DropAnimation(1, 2));
        }

        private IEnumerator DropAnimation(float endValue, float duration)
        {
            float time = 0;
            const float startValue = 0;
            while (time < duration)
            {
                float lerp = Mathf.Lerp(startValue, endValue, time / duration);
                transform.position = Vector3.Lerp(_startPosition, _dropPosition, lerp);
                time += Time.deltaTime;
                yield return null;
            }

            transform.position = _dropPosition;
        }
        
        private IEnumerator LerpColor(float endValue, float duration)
        {
            float time = 0;
            const float startValue = 0;
            while (time < duration)
            {
                float lerp = Mathf.Lerp(startValue, endValue, time / duration);
                meshRenderer.material.color = Color.Lerp(_startColor, lerpColor, lerp);
                time += Time.deltaTime;
                yield return null;
            }

            meshRenderer.material.color = lerpColor;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(detectTransform.position, radius);
        }
    }
}