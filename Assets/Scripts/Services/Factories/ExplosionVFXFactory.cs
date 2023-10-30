using Services.Data;
using UnityEngine;

namespace Services.Factories
{
    public class ExplosionVFXFactory
    {
        private readonly ConfigProvider _configProvider;

        private ExplosionVFXFactory(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        
        public GameObject Create()
        {
            return Object.Instantiate(_configProvider.BombConfig.ExplosionVFX);
        }
    }
}