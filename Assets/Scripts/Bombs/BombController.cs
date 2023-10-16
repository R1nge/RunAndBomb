using System;
using Services.Factories;
using UnityEngine;
using Zenject;

namespace Bombs
{
    public class BombController : MonoBehaviour
    {
        public event Action OnTimerStarted, OnTimerEnded;
        public event Action<float, float> OnTimerChanged;
        [SerializeField] private float throwInterval;
        [SerializeField] private Transform model;
        [SerializeField, Range(1, 500)] private float maxThrowForce;
        private BombFactory _bombFactory;
        private float _currentTime;
        private bool _canThrow = true;

        [Inject]
        private void Inject(BombFactory bombFactory) => _bombFactory = bombFactory;

        private void Awake() => _currentTime = throwInterval;

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

            return true;
        }

        private void Update()
        {
            if (!_canThrow)
            {
                OnTimerStarted?.Invoke();

                _currentTime -= Time.deltaTime;

                OnTimerChanged?.Invoke(_currentTime, throwInterval);

                if (_currentTime <= 0)
                {
                    _canThrow = true;
                    _currentTime = throwInterval;
                    OnTimerEnded?.Invoke();
                }
            }
        }
    }
}