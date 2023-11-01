using System.Threading.Tasks;
using Services.Data;
using UnityEngine;

namespace Services.Assets
{
    public class ExplosionVFXAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private GameObject _cached;

        private ExplosionVFXAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<GameObject> LoadExplosionVFX()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject explosionVFX = await LoadAsset(_configProvider.BombConfig.ExplosionVFX);
            _cached = explosionVFX;
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached);
            _cached = null;
        }
    }
}