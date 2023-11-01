namespace Services
{
    public class KillService
    {
        private readonly VibrationService _vibrationService;
        private readonly UIService _uiService;

        private KillService(VibrationService vibrationService, UIService uiService)
        {
            _vibrationService = vibrationService;
            _uiService = uiService;
        }

        public void Kill()
        {
            _vibrationService.VibrateSingle();
            _uiService.ShowKillPopup();
        }
    }
}