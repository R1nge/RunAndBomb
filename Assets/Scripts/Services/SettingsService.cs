namespace Services
{
    public class SettingsService
    {
        private Settings _settings;

        public Settings Settingss => _settings;

        public void SetSoundStatus(bool isEnabled) => _settings.SoundEnabled = isEnabled;

        public void SetVibrationStatus(bool isEnabled) => _settings.VibrationEnabled = isEnabled;

        public struct Settings
        {
            public bool SoundEnabled;
            public bool VibrationEnabled;
        }
    }
}