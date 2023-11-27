using System;
using Services.Data.Notifications;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;

namespace Services
{
    public class NotificationService
    {
        private readonly INotificationDataService _notificationDataService;

        private NotificationService(INotificationDataService notificationDataService)
        {
            _notificationDataService = notificationDataService;
        }
        
        public void RequestNotificationPermission()
        {
            if (GetSDKLevel() >= 33)
            {
                if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
                {
                    Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
                }   
            }
        }

        public void RegisterNotificationChannel()
        {
            var channel = new AndroidNotificationChannel
            {
                Id = "channel_id",
                Name = "Default",
                Importance = Importance.Default,
                Description = "Generic notification"
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }

        public void SendNotification(string title, string text, DateTime dateTime)
        {
            if (_notificationDataService.Model.FireTime > dateTime)
            {
                var notification = new AndroidNotification
                {
                    Title = title,
                    Text = text,
                    FireTime = dateTime,
                    SmallIcon = "small_icon" 
                };
            
                AndroidNotificationCenter.SendNotification(notification, "channel_id");
                
                _notificationDataService.Model.FireTime = dateTime;
                _notificationDataService.Save();
            }
            else
            {
                Debug.Log("Notification is already scheduled");
            }
        }

        private int GetSDKLevel() 
        {
            IntPtr clazz = AndroidJNI.FindClass("android/os/Build$VERSION");
            IntPtr fieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
            int sdkLevel = AndroidJNI.GetStaticIntField(clazz, fieldID);
            return sdkLevel;
        }
    }
}