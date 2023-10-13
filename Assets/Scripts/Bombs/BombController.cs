using System.Collections;
using Services;
using UnityEngine;
using VContainer;

namespace Bombs
{
    public class BombController : MonoBehaviour
    {
        [SerializeField] private float throwInterval;
        [SerializeField] private Transform model;
        [SerializeField, Range(1, 5)] private float maxThrowForce;
        private float _currentThrowForce;
        private BombFactory _bombFactory;
        private bool _canThrow = true;

        [Inject]
        private void Inject(BombFactory bombFactory) => _bombFactory = bombFactory;

        public void SetCurrentThrowForce(float force)
        {
            _currentThrowForce = Mathf.Clamp(force, 0, maxThrowForce);
        }

        public bool TryThrow()
        {
            if (!_canThrow)
            {
                return false;
            }

            _canThrow = false;

            var bomb = _bombFactory.Create(0);
            bomb.transform.position = transform.position;
            bomb.Throw(model.transform.forward, _currentThrowForce);
            StartCoroutine(ResetThrow());

            return true;
        }

        private IEnumerator ResetThrow()
        {
            yield return new WaitForSeconds(throwInterval);
            _canThrow = true;
        }
    }
}