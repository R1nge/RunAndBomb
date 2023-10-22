using System.Threading.Tasks;
using Services.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services.Assets
{
    public class LoadingScreenAssetProvider : LocalAssetProvider
    {
        private readonly ConfigProvider _configProvider;
        private AsyncOperationHandle<GameObject> _cached;

        private LoadingScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<LoadingScreen> LoadLoadingScreenAsset()
        {
            if (_cached.IsValid())
            {
                return _cached.Result.GetComponent<LoadingScreen>();
            }
            
            _cached = Addressables.LoadAssetAsync<GameObject>(_configProvider.UIConfig.LoadingScreen);
            await _cached.Task;
            return _cached.Result.GetComponent<LoadingScreen>();
        }

        public void Unload()
        {
            if (_cached.IsValid())
            {
                Unload(_cached);
            }
        }
    }
}