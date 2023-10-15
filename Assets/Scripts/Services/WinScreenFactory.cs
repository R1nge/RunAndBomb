using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class WinScreenFactory : IUIFactory<WinUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly WinUI _win;

        public WinScreenFactory(IObjectResolver objectResolver, WinUI win)
        {
            _objectResolver = objectResolver;
            _win = win;
        }

        public WinUI Create() => _objectResolver.Instantiate(_win);
    }
}