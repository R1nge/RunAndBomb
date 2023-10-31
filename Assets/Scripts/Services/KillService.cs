namespace Services
{
    public class KillService
    {
        private readonly VibrationService _vibrationService;
        private readonly PopupService _popupService;

        private KillService(VibrationService vibrationService, PopupService popupService)
        {
            _vibrationService = vibrationService;
            _popupService = popupService;
        }

        public void Kill()
        {
            _vibrationService.VibrateSingle();
            _popupService.ActivateKillPopup();
        }
    }
}