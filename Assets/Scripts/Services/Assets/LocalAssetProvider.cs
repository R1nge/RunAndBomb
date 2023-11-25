using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services.Assets
{
    public class LocalAssetProvider
    {
        protected async Task<GameObject> LoadAsset(string path)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(path);
            await handle.Task;
            return handle.Result;
        }

        protected async Task<GameObject> LoadAsset(AssetReferenceGameObject assetReference)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await handle.Task;
            return handle.Result;
        }

        protected void Unload(AsyncOperationHandle<GameObject> operationHandle)
        {
            Addressables.Release(operationHandle);
        }

        protected void Unload(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}