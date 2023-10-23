using Services.Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services
{
    public class Boot : MonoBehaviour
    {
        private LoadingScreenAssetProvider _loadingScreenAssetProvider;
        private StartScreenAssetProvider _startScreenAssetProvider;
        
        [Inject]
        private void Inject(LoadingScreenAssetProvider loadingScreenAssetProvider, StartScreenAssetProvider startScreenAssetProvider)
        {
            _loadingScreenAssetProvider = loadingScreenAssetProvider;
            _startScreenAssetProvider = startScreenAssetProvider;
        }
        
        private async void Start()
        {
            await _loadingScreenAssetProvider.LoadLoadingScreenAsset();
            await _startScreenAssetProvider.LoadStartUIAsset();
            SceneManager.LoadSceneAsync("Game");
        }
    }
}