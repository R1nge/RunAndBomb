using System.Threading.Tasks;
using Services.Data;
using UIs;
using UnityEngine;

namespace Services.Assets
{
    public class StartScreenAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private StartUI _cached;

        private StartScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<StartUI> LoadStartUIAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject startUI = await LoadAsset(_configProvider.UIConfig.StartScreen);
            _cached = startUI.GetComponent<StartUI>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}