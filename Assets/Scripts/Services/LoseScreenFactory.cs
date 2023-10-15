using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class LoseScreenFactory : IUIFactory<EndUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EndUI _loseScreen;

        public LoseScreenFactory(IObjectResolver objectResolver, EndUI loseScreen)
        {
            _objectResolver = objectResolver;
            _loseScreen = loseScreen;
        }

        public EndUI Create() => _objectResolver.Instantiate(_loseScreen);
    }
}