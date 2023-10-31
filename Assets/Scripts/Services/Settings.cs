namespace Services
{
    public class Settings
    {
        public bool SoundEnabled;
        public bool VibrationEnabled;

        public Settings(bool soundsEnabled, bool vibrationEnabled)
        {
            SoundEnabled = soundsEnabled;
            VibrationEnabled = vibrationEnabled;
        }
    }
}