using Services.Data;
using UIs;
using Zenject;

namespace Services.Factories
{
    public class StartScreenFactory : IUIFactory<StartUI>
    {
        private readonly DiContainer _container;
        private readonly ConfigProvider _configProvider;

        private StartScreenFactory(DiContainer container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        //For some reason VContainer put it in a DDOL
        public StartUI Create() => _container.InstantiatePrefabForComponent<StartUI>(_configProvider.UIConfig.StartScreen);
    }
}