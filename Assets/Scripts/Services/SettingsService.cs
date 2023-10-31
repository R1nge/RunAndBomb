using System;
using Services.Data.Settings;

namespace Services
{
    public class SettingsService
    {
        public event Action<bool> OnSoundsStatusChanged;
        public event Action<bool> OnVibrationStatusChanged;
        private readonly ISettingsDataService _settingsDataService;

        private SettingsService(ISettingsDataService settingsDataService) => _settingsDataService = settingsDataService;

        public void SetSoundStatus(bool isEnabled)
        {
            _settingsDataService.Model.SoundEnabled = isEnabled;
            OnSoundsStatusChanged?.Invoke(isEnabled);
        }

        public void SetVibrationStatus(bool isEnabled)
        {
            _settingsDataService.Model.VibrationEnabled = isEnabled;
            OnVibrationStatusChanged?.Invoke(isEnabled);
        }
    }
}