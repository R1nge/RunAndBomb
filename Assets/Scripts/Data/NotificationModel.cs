using System;

namespace Data
{
    [Serializable]
    public class NotificationModel
    {
        public DateTime FireTime { get; set; }

        public NotificationModel(DateTime fireTime)
        {
            FireTime = fireTime;
        }
    }
}