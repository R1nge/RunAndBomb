using Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services.Factories
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UIConfig _uiConfig;

        private LoseScreenFactory(IObjectResolver objectResolver, UIConfig uiConfig)
        {
            _objectResolver = objectResolver;
            _uiConfig = uiConfig;
        }

        public LoseUI Create() => _objectResolver.Instantiate(_uiConfig.Lose);
    }
}