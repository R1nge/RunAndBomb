using Services.Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class StartScreenFactory : IUIFactory<StartUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private StartScreenFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        //For some reason VContainer put it in a DDOL
        public StartUI Create() => _objectResolver.Instantiate(_configProvider.UIConfig.StartScreen);
    }
}