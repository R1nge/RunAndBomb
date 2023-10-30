namespace Services
{
    public class KillService
    {
        private readonly VibrationService _vibrationService;
        //PopupService;

        private KillService(VibrationService vibrationService)
        {
            _vibrationService = vibrationService;
        }

        public void Kill()
        {
            _vibrationService.VibrateSingle();
        }
    }
}