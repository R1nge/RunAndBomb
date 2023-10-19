using System.Threading.Tasks;
using Services.Assets;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly DiContainer _container;
        private readonly LoseScreenAssetProvider _loseScreenAssetProvider;

        private LoseScreenFactory(DiContainer container, LoseScreenAssetProvider loseScreenAssetProvider)
        {
            _container = container;
            _loseScreenAssetProvider = loseScreenAssetProvider;
        }

        public async Task<LoseUI> Create()
        {
            Task<LoseUI> loseUIAsset = _loseScreenAssetProvider.LoadWinUIAsset();
            await loseUIAsset;
            return _container.InstantiatePrefabForComponent<LoseUI>(loseUIAsset.Result);
        }
    }
}