using System.Threading.Tasks;
using Services.Assets;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class StartScreenFactory : IUIFactory<StartUI>
    {
        private readonly DiContainer _container;
        private readonly StartScreenAssetProvider _startScreenAssetProvider;

        private StartScreenFactory(DiContainer container, StartScreenAssetProvider startScreenAssetProvider)
        {
            _container = container;
            _startScreenAssetProvider = startScreenAssetProvider;
        }

        //For some reason VContainer put it in a DDOL
        public async Task<StartUI> Create()
        {
            Task<StartUI> startUIAsset = _startScreenAssetProvider.LoadStartUIAsset();
            await startUIAsset;
            return _container.InstantiatePrefabForComponent<StartUI>(startUIAsset.Result);
        }
    }
}