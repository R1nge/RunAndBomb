using System.Threading.Tasks;
using Services.Data;
using UIs;
using UnityEngine;

namespace Services.Assets
{
    public class LoseScreenAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private LoseUI _cached;

        private LoseScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<LoseUI> LoadWinUIAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }

            GameObject loseUI = await LoadAsset(_configProvider.UIConfig.Lose);
            _cached = loseUI.GetComponent<LoseUI>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}