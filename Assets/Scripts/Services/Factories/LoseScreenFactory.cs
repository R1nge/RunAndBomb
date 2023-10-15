using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private LoseScreenFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public LoseUI Create() => _objectResolver.Instantiate(_configProvider.UIConfig.Lose);
    }
}