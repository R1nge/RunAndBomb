using System.Threading.Tasks;
using Data;
using Enemies;
using Services.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = System.Random;

namespace Services.Assets
{
    public class EnemyAssetProvider : LocalAssetProvider
    {
        private readonly Random _random = new();
        private readonly ConfigProvider _configProvider;

        private EnemyAssetProvider(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }
        
        public async Task<Enemy> GetRandomSkin()
        {
            EnemySkinsConfig enemyConfig = _configProvider.EnemySkinsConfig;
            int index = _random.Next(0, enemyConfig.Skins.Length);
            AssetReferenceGameObject skin = enemyConfig.Skins[index];
            AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(skin);
            await asset.Task;
            return asset.Result.GetComponent<Enemy>();
        }
    }
}