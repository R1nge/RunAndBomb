using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class GamePlayScreenFactory : IUIFactory<InGameUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly InGameUI _inGameUI;

        public GamePlayScreenFactory(IObjectResolver objectResolver, InGameUI inGameUI)
        {
            _objectResolver = objectResolver;
            _inGameUI = inGameUI;
        }

        public InGameUI Create() => _objectResolver.Instantiate(_inGameUI);
    }
}