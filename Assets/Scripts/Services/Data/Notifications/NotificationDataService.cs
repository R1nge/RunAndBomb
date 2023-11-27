using Data;

namespace Services.Data.Notifications
{
    public class NotificationDataService : INotificationDataService
    {
        private readonly INotificationDataProvider _notificationDataProvider;
        private NotificationModel _model;

        public NotificationDataService(INotificationDataProvider notificationDataProvider) => _notificationDataProvider = notificationDataProvider;

        public NotificationModel Model => _model;
        
        public void Save() => _notificationDataProvider.Save(_model);
        public void Load() => _model = _notificationDataProvider.Load();
    }
}