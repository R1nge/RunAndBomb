using Services.Data;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class GamePlayScreenFactory : IUIFactory<InGameUI>
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private GamePlayScreenFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public InGameUI Create() => _container.InstantiatePrefabForComponent<InGameUI>(_configProvider.UIConfig.GamePlayScreen);
    }
}