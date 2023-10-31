using Services.Data.Settings;

namespace Services
{
    public class VibrationService
    {
        private readonly ISettingsDataService _settingsDataService;

        private VibrationService(ISettingsDataService settingsDataService) => _settingsDataService = settingsDataService;

        public void VibrateSingle()
        {
            if (_settingsDataService.Model.VibrationEnabled)
            {
                Vibration.VibratePeek();
            }
        }
    }
}