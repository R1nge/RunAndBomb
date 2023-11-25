using Common;
using Services.Data;
using Services.Factories;
using UnityEngine;
using Zenject;

namespace Bombs
{
    public abstract class BombController : MonoBehaviour
    {
        [SerializeField] private Transform bombSpawnPoint;
        [SerializeField] protected float throwInterval;
        [SerializeField] private float force;
        private SizeController _sizeController;
        protected BombProperties BombProperties;
        private BombFactory _bombFactory;
        private ConfigProvider _configProvider;
        protected bool IsPlayer;
        protected float CurrentTime;
        protected bool _canThrow = true;
        private float _multiplier;
        private int _bombSkinIndex;

        public bool CanThrow => _canThrow;

        [Inject]
        private void Inject(BombFactory bombFactory, ConfigProvider configProvider)
        {
            _bombFactory = bombFactory;
            _configProvider = configProvider;
        }

        protected virtual void Awake()
        {
            _sizeController = GetComponent<SizeController>();
            
            BombProperties = new BombProperties();

            CurrentTime = throwInterval;

            _bombSkinIndex = Random.Range(0, _configProvider.BombSkinsConfig.Bombs.Length);
        }

        public virtual void Process()
        {
            if (_canThrow)
            {
                Predict();
            }
            else
            {
                CurrentTime -= Time.deltaTime;
            }
        }

        protected void ResetTimer()
        {
            if (CurrentTime <= 0)
            {
                _canThrow = true;
                CurrentTime = throwInterval;
            }
        }

        public void SetMultiplier(float multiplier) => BombProperties.InitialSpeed = force * multiplier;

        private void Predict()
        {
            BombProperties.Mass = _configProvider.BombConfig.Mass;
            BombProperties.Drag = _configProvider.BombConfig.Drag;
            BombProperties.Direction = bombSpawnPoint.transform.forward;
            BombProperties.InitialPosition = bombSpawnPoint.transform.position;
            BombProperties.Gravity = Physics.gravity * BombProperties.Mass;
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
            bomb.GetComponent<RigidbodyGravity>().SetBombProperties(BombProperties);

            Vector3 force = BombProperties.Direction * (BombProperties.InitialSpeed / BombProperties.Mass);
            
            //TODO: find a better solution, maybe create an enemy and player bomb using factory
            bomb.Throw(force, _sizeController, IsPlayer);

            return true;
        }
    }
}