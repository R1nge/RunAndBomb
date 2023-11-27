namespace Services.Data.Notifications
{
    public class NotificationDataLoadingOperation : ILoadingOperation
    {
        private readonly INotificationDataService _notificationDataService;
        
        public NotificationDataLoadingOperation(INotificationDataService notificationDataService) => _notificationDataService = notificationDataService;

        public void Load() => _notificationDataService.Load();
    }
}