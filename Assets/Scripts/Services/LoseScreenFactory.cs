using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly LoseUI _loseScreen;

        public LoseScreenFactory(IObjectResolver objectResolver, LoseUI loseScreen)
        {
            _objectResolver = objectResolver;
            _loseScreen = loseScreen;
        }

        public LoseUI Create() => _objectResolver.Instantiate(_loseScreen);
    }
}