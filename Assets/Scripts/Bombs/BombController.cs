using System;
using Common;
using Data;
using Services.Data;
using Services.Factories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Bombs
{
    public class BombController : MonoBehaviour
    {
        public event Action OnTimerStarted, OnTimerEnded;
        public event Action<float, float> OnTimerChanged;
        [SerializeField] private Transform bombSpawnPoint;
        [SerializeField] private float throwInterval;
        [SerializeField] private float force;
        [SerializeField] private BombConfig bombConfig;
        private SizeController _sizeController;
        private TrajectoryPredictor _trajectoryPredictor;
        private BombProperties _bombProperties;
        private BombFactory _bombFactory;
        private ConfigProvider _configProvider;
        private float _currentTime;
        private bool _canThrow = true;
        private float _multiplier;
        private bool _hasTrajectoryPredictor;
        private int _bombSkinIndex;

        public bool CanThrow => _canThrow;

        [Inject]
        private void Inject(BombFactory bombFactory, ConfigProvider configProvider)
        {
            _bombFactory = bombFactory;
            _configProvider = configProvider;
        }

        private void Awake()
        {
            _sizeController = GetComponent<SizeController>();
            
            _bombProperties = new BombProperties();

            _currentTime = throwInterval;

            _hasTrajectoryPredictor = TryGetComponent(out TrajectoryPredictor trajectoryPredictor);

            if (_hasTrajectoryPredictor)
            {
                _trajectoryPredictor = trajectoryPredictor;
            }

            _bombSkinIndex = Random.Range(0, _configProvider.BombSkinsConfig.Bombs.Length);
        }

        public void Process()
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
                
                if (_hasTrajectoryPredictor)
                {
                    Draw();
                }
            }
        }

        public void SetMultiplier(float multiplier) => _bombProperties.InitialSpeed = force * multiplier;

        private void Predict()
        {
            _bombProperties.Mass = bombConfig.Mass;
            _bombProperties.Drag = bombConfig.Drag;
            _bombProperties.Direction = bombSpawnPoint.transform.forward;
            _bombProperties.InitialPosition = bombSpawnPoint.transform.position;
            _bombProperties.Gravity = Physics.gravity * _bombProperties.Mass;
        }

        private void Draw()
        {
            _trajectoryPredictor.PredictTrajectory(_bombProperties);
        }

        public bool TryThrow()
        {
            if (!_canThrow)
            {
                return false;
            }

            _canThrow = false;

            Bomb bomb = _bombFactory.Create(_bombSkinIndex);
            bomb.transform.position = bombSpawnPoint.position;
            bomb.GetComponent<RigidbodyGravity>().SetBombProperties(_bombProperties);

            Vector3 force = _bombProperties.Direction * (_bombProperties.InitialSpeed / _bombProperties.Mass);
            
            //Velocity , Angle , Initial Position
            //force, angle, InitialPosition
            
            //Time = 2 * force * sin(angle) / gravity

            // print($"Angle {(360 - bombSpawnPoint.rotation.eulerAngles.x) % 360}");
            //
            // float sinus = Mathf.Sin((360 - bombSpawnPoint.rotation.eulerAngles.x) % 360);
            // float time = force.magnitude * (2 * sinus / _bombProperties.Gravity.y);
            //
            // //time *= 2.57085f;
            //
            // print(time);
            
            bomb.Throw(force, _sizeController);

            return true;
        }
    }
}