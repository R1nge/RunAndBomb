namespace Services
{
    public class VibrationService
    {
        private readonly SettingsService _settingsService;
        
        private VibrationService(SettingsService settingsService) => _settingsService = settingsService;

        public void VibrateSingle()
        {
            if (_settingsService.Settingss.VibrationEnabled)
            {
                Vibration.VibratePeek();
            }
        }
    }
}