﻿using Data;
using UIs;
using VContainer;
using VContainer.Unity;

namespace Services
{
    public class WinScreenFactory : IUIFactory<WinUI>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UIConfig _uiConfig;

        public WinScreenFactory(IObjectResolver objectResolver, UIConfig uiConfig)
        {
            _objectResolver = objectResolver;
            _uiConfig = uiConfig;
        }

        public WinUI Create() => _objectResolver.Instantiate(_uiConfig.Win);
    }
}