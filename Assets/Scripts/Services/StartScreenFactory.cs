using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class StartScreenFactory : IUIFactory<StartUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly StartUI _window;

        public StartScreenFactory(IObjectResolver objectResolver, StartUI window)
        {
            _objectResolver = objectResolver;
            _window = window;
        }

        public StartUI Create() => _objectResolver.Instantiate(_window);
    }
}