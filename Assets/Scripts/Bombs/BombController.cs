using System.Collections;
using Services.Factories;
using UnityEngine;
using Zenject;

namespace Bombs
{
    public class BombController : MonoBehaviour
    {
        [SerializeField] private float throwInterval;
        [SerializeField] private Transform model;
        [SerializeField, Range(1, 500)] private float maxThrowForce;
        private BombFactory _bombFactory;
        private bool _canThrow = true;

        [Inject]
        private void Inject(BombFactory bombFactory) => _bombFactory = bombFactory;

        public bool TryThrow(float multiplier)
        {
            if (!_canThrow)
            {
                return false;
            }

            _canThrow = false;

            var bomb = _bombFactory.Create(0);
            bomb.transform.position = transform.position;
            bomb.SetOwner(gameObject);
            bomb.Throw(model.transform.forward, maxThrowForce * multiplier);
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