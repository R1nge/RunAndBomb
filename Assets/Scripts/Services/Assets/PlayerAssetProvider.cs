using System.Threading.Tasks;
using Players;
using Services.Data;
using UnityEngine;

namespace Services.Assets
{
    public class PlayerAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private Player _cached;

        private PlayerAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<Player> LoadPlayerAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject player = await LoadAsset(_configProvider.PlayerConfig.PlayerPrefab);
            _cached = player.GetComponent<Player>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}