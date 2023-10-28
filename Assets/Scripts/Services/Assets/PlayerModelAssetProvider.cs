using System.Threading.Tasks;
using Services.Data;
using UnityEngine;

namespace Services.Assets
{
    public class PlayerModelAssetProvider: LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private GameObject _cached;

        private PlayerModelAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<GameObject> LoadPlayerAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject player = await LoadAsset(_configProvider.PlayerConfig.PlayerModelPrefab);
            _cached = player;
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}