using Data;

namespace Services.Data.Notifications
{
    public interface INotificationDataProvider
    {
        public NotificationModel Load();
        public void Save(NotificationModel data);
    }
}