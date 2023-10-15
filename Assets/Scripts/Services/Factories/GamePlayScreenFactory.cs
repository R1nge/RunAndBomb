using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class GamePlayScreenFactory : IUIFactory<InGameUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private GamePlayScreenFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public InGameUI Create() => _objectResolver.Instantiate(_configProvider.UIConfig.GamePlayScreen);
    }
}