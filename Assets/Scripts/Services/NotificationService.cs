using System;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;

namespace Services
{
    public class NotificationService
    {
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
            var notification = new AndroidNotification
            {
                Title = title,
                Text = text,
                FireTime = dateTime,
                SmallIcon = "small_icon" 
            };
            
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

        private int GetSDKLevel() {
            IntPtr clazz = AndroidJNI.FindClass("android/os/Build$VERSION");
            IntPtr fieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
            int sdkLevel = AndroidJNI.GetStaticIntField(clazz, fieldID);
            return sdkLevel;
        }
    }
}