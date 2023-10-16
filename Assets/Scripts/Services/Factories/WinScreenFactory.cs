using Services.Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class WinScreenFactory : IUIFactory<WinUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private WinScreenFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public WinUI Create() => _objectResolver.Instantiate(_configProvider.UIConfig.Win);
    }
}