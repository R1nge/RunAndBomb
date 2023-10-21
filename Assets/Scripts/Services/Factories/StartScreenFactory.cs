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

        public async Task<StartUI> Create()
        {
            Task<StartUI> screen = _startScreenAssetProvider.LoadStartUIAsset();
            await screen;
            _container.Inject(screen.Result);
            return screen.Result;
        }
    }
}