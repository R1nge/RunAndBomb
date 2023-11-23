namespace Services
{
    public class Settings
    {
        public bool SoundEnabled;
        public bool VibrationEnabled;
        public LocalizationService.Languages Language;

        public Settings(bool soundsEnabled, bool vibrationEnabled, LocalizationService.Languages languages)
        {
            SoundEnabled = soundsEnabled;
            VibrationEnabled = vibrationEnabled;
            Language = languages;
        }
    }
}