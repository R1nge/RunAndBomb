using System.Threading.Tasks;
using Services.Data;
using UIs;
using UnityEngine;

namespace Services.Assets
{
    public class InGameUIAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private InGameUI _cached;

        private InGameUIAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<InGameUI> LoadInGameUIAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject inGameUI = await LoadAsset(_configProvider.UIConfig.GamePlayScreen);
            _cached = inGameUI.GetComponent<InGameUI>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}