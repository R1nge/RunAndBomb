using System.Threading.Tasks;
using Services.Data;
using UnityEngine;

namespace Services.Assets
{
    public class LoadingScreenAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private LoadingScreen _cached;

        private LoadingScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<LoadingScreen> LoadLoadingScreenAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject loadingScreen = await LoadAsset(_configProvider.UIConfig.LoadingScreen);
            _cached = loadingScreen.GetComponent<LoadingScreen>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}