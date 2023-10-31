namespace Services.Data.Settings
{
    public class SettingsDataLoadingOperation : ILoadingOperation
    {
        private readonly ISettingsDataService _settingsDataService;
        
        public SettingsDataLoadingOperation(ISettingsDataService settingsDataService) => _settingsDataService = settingsDataService;

        public void Load() => _settingsDataService.Load();
    }
}