using System.Threading.Tasks;
using Services.Assets;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class WinScreenFactory : IUIFactory<WinUI>
    {
        private readonly DiContainer _container;
        private readonly WinUIAssetProvider _winUIAssetProvider;

        private WinScreenFactory(DiContainer container, WinUIAssetProvider winUIAssetProvider)
        {
            _container = container;
            _winUIAssetProvider = winUIAssetProvider;
        }

        public async Task<WinUI> Create()
        {
            Task<WinUI> winUIAsset = _winUIAssetProvider.LoadWinUIAsset();
            await winUIAsset;
            return _container.InstantiatePrefabForComponent<WinUI>(winUIAsset.Result);
        }
    }
}