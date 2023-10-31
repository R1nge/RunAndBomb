using System;

namespace Services.Data.Settings
{
    public class SettingsDataService : ISettingsDataService
    {
        private readonly ISettingsDataProvider _settingsDataProvider;
        private Services.Settings _model;

        public SettingsDataService(ISettingsDataProvider settingsDataProvider) => _settingsDataProvider = settingsDataProvider;

        public Services.Settings Model => _model;
        public event Action<Services.Settings> OnModelLoaded;

        public void Save() => _settingsDataProvider.Save(_model);
        public void Load()
        {
            _model = _settingsDataProvider.Load();
            OnModelLoaded?.Invoke(_model);
        }
    }
}