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
        [SerializeField] private Transform bombSpawnPoint;
        [SerializeField] private Rigidbody objectToThrow;
        [SerializeField] private float throwInterval;
        [SerializeField, Range(0.001f, 3f)] private float force;
        private TrajectoryPredictor _trajectoryPredictor;
        private BombProperties _bombProperties;
        private BombFactory _bombFactory;
        private float _currentTime;
        private bool _canThrow = true;
        private float _multiplier;

        [Inject]
        private void Inject(BombFactory bombFactory) => _bombFactory = bombFactory;

        private void Awake()
        {
            _currentTime = throwInterval;

            _trajectoryPredictor = GetComponent<TrajectoryPredictor>();

            var rigidbody = objectToThrow.GetComponent<Rigidbody>();

            _bombProperties = new BombProperties
            {
                Mass = rigidbody.mass,
                Drag = rigidbody.drag
            };
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
            else
            {
                Predict();
            }
        }

        public void SetMultiplier(float multiplier) => _bombProperties.InitialSpeed = force * multiplier;

        private void Predict()
        {
            _bombProperties.Direction = bombSpawnPoint.transform.forward;
            _bombProperties.InitialPosition = bombSpawnPoint.transform.position;
            _trajectoryPredictor.PredictTrajectory(_bombProperties);
        }

        public bool TryThrow()
        {
            if (!_canThrow)
            {
                return false;
            }

            _canThrow = false;

            Bomb bomb = _bombFactory.Create(0);
            bomb.transform.position = bombSpawnPoint.position;
            bomb.SetOwner(gameObject);

            Vector3 force = bombSpawnPoint.forward * _bombProperties.InitialSpeed;

            bomb.Throw(force);

            return true;
        }
    }
}