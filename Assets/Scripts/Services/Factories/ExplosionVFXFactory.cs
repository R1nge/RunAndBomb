using Services.Data;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class ExplosionVFXFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ConfigProvider _configProvider;

        private ExplosionVFXFactory(DiContainer diContainer, ConfigProvider configProvider)
        {
            _diContainer = diContainer;
            _configProvider = configProvider;
        }
        
        public GameObject Create() => _diContainer.InstantiatePrefab(_configProvider.BombConfig.ExplosionVFX);
    }
}