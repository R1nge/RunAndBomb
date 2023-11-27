using Data;

namespace Services.Data.Notifications
{
    public interface INotificationDataService
    {
        void Save();
        void Load();
        NotificationModel Model { get; }
    }
}