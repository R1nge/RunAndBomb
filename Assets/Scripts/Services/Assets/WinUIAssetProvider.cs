using System.Threading.Tasks;
using Services.Data;
using UIs;
using UnityEngine;

namespace Services.Assets
{
    public class WinUIAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private WinUI _cached;

        private WinUIAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<WinUI> LoadWinUIAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject winUI = await LoadAsset(_configProvider.UIConfig.Win);
            _cached = winUI.GetComponent<WinUI>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}