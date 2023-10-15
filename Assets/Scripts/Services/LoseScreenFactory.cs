using Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UIConfig _uiConfig;

        public LoseScreenFactory(IObjectResolver objectResolver, UIConfig uiConfig)
        {
            _objectResolver = objectResolver;
            _uiConfig = uiConfig;
        }

        public LoseUI Create() => _objectResolver.Instantiate(_uiConfig.Lose);
    }
}