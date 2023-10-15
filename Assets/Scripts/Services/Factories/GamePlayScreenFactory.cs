using Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class GamePlayScreenFactory : IUIFactory<InGameUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UIConfig _uiConfig;

        private GamePlayScreenFactory(IObjectResolver objectResolver, UIConfig uiConfig)
        {
            _objectResolver = objectResolver;
            _uiConfig = uiConfig;
        }

        public InGameUI Create() => _objectResolver.Instantiate(_uiConfig.GamePlayScreen);
    }
}