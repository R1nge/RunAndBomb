using System.Threading.Tasks;
using Services.Assets;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class GamePlayScreenFactory : IUIFactory<InGameUI>
    {
        private readonly DiContainer _container;
        private readonly InGameUIAssetProvider _inGameUIAssetProvider;

        private GamePlayScreenFactory(DiContainer container, InGameUIAssetProvider inGameUIAssetProvider)
        {
            _container = container;
            _inGameUIAssetProvider = inGameUIAssetProvider;
        }

        public async Task<InGameUI> Create()
        {
            Task<InGameUI> inGameUIAsset = _inGameUIAssetProvider.LoadInGameUIAsset();
            await inGameUIAsset;
            return _container.InstantiatePrefabForComponent<InGameUI>(inGameUIAsset.Result);
        }
    }
}