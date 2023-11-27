using System;
using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.Data.Notifications
{
    public class NotificationPlayerPrefsDataProvider : INotificationDataProvider
    {
        private const string DATA_KEY = "NotificationData";

        public void Save(NotificationModel data)
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(DATA_KEY, json);
            PlayerPrefs.Save();
        }

        public NotificationModel Load()
        {
            NotificationModel data;

            string json = PlayerPrefs.GetString(DATA_KEY);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Notification data doesn't exist. Creating a new one");
                data = new NotificationModel(DateTime.UtcNow + TimeSpan.FromDays(1));
            }
            else
            {
                data = JsonConvert.DeserializeObject<NotificationModel>(json);
            }

            return data;
        }
    }
}