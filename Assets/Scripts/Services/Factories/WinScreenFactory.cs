using Services.Data;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class WinScreenFactory : IUIFactory<WinUI>
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private WinScreenFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public WinUI Create() => _container.InstantiatePrefabForComponent<WinUI>(_configProvider.UIConfig.Win);
    }
}