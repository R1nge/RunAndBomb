using System.Threading.Tasks;
using Services.Data;
using UIs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services.Assets
{
    public class StartScreenAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private AsyncOperationHandle<GameObject> _cached;

        private StartScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<StartUI> LoadStartUIAsset()
        {
            if (_cached.IsValid())
            {
                return _cached.Result.GetComponent<StartUI>();
            }
            
            _cached = Addressables.LoadAssetAsync<GameObject>(_configProvider.UIConfig.StartScreen);
            await _cached.Task;
            return _cached.Result.GetComponent<StartUI>();
        }

        public void Unload()
        {
            Unload(_cached);
        }
    }
}