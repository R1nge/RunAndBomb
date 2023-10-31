using Services.Data.Settings;

namespace Services
{
    public class SettingsService
    {
        private readonly ISettingsDataService _settingsDataService;

        private SettingsService(ISettingsDataService settingsDataService) => _settingsDataService = settingsDataService;

        public void SetSoundStatus(bool isEnabled) => _settingsDataService.Model.SoundEnabled = isEnabled;

        public void SetVibrationStatus(bool isEnabled) => _settingsDataService.Model.VibrationEnabled = isEnabled;
    }
}