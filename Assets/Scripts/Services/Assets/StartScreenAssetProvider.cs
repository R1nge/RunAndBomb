﻿using System.Threading.Tasks;
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
        private StartUI _cached;

        private StartScreenAssetProvider(ConfigProvider configProvider) => _configProvider = configProvider;

        public async Task<StartUI> LoadStartUIAsset()
        {
            if (_cached != null)
            {
                return _cached;
            }
            
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(_configProvider.UIConfig.StartScreen);
            await handle.Task;
            _cached = handle.Result.GetComponent<StartUI>();
            return _cached;
        }

        public void Unload()
        {
            Unload(_cached.gameObject);
            _cached = null;
        }
    }
}