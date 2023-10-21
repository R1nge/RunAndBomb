using System.Threading.Tasks;
using Services.Assets;
using UIs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Services.Factories
{
    public class LoadingScreenFactory : IUIFactory<LoadingScreen>
    {
        private readonly DiContainer _container;
        private readonly LoadingScreenAssetProvider _loadingScreenAssetProvider;

        private LoadingScreenFactory(DiContainer container, LoadingScreenAssetProvider loadingScreenAssetProvider)
        {
            _container = container;
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
        }
        
        public async Task<LoadingScreen> Create()
        {
            Task<LoadingScreen> screen = _loadingScreenAssetProvider.LoadLoadingScreenAsset();
            await screen;
            return screen.Result;
        }

        public void Release()
        {
            _loadingScreenAssetProvider.Unload();
        }
    }
}