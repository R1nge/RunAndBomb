using Services.Data;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class LoseScreenFactory : IUIFactory<LoseUI>
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private LoseScreenFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public LoseUI Create() => _container.InstantiatePrefabForComponent<LoseUI>(_configProvider.UIConfig.Lose);
    }
}