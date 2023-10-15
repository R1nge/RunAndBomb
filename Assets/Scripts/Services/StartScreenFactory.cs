using Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class StartScreenFactory : IUIFactory<StartUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UIConfig _uiConfig;

        public StartScreenFactory(IObjectResolver objectResolver, UIConfig uiConfig)
        {
            _objectResolver = objectResolver;
            _uiConfig = uiConfig;
        }

        public StartUI Create() => _objectResolver.Instantiate(_uiConfig.StartScreen);
    }
}