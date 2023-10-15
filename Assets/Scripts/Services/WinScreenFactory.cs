using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class WinScreenFactory : IUIFactory<EndUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EndUI _win;

        public WinScreenFactory(IObjectResolver objectResolver, EndUI win)
        {
            _objectResolver = objectResolver;
            _win = win;
        }

        public EndUI Create() => _objectResolver.Instantiate(_win);
    }
}