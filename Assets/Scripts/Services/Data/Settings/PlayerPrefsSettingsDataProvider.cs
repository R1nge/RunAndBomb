using Newtonsoft.Json;
using UnityEngine;

namespace Services.Data.Settings
{
    public class PlayerPrefsSettingsDataProvider : ISettingsDataProvider
    {
        private const string DATA_KEY = "SettingsData";
        
        public Services.Settings Load()
        {
            Services.Settings data;

            string json = PlayerPrefs.GetString(DATA_KEY);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Data doesn't exist. Creating a new one");
                data = new Services.Settings(true, true, LocalizationService.Languages.EN);
            }
            else
            {
                data = JsonConvert.DeserializeObject<Services.Settings>(json);
            }

            return data;
        }

        public void Save(Services.Settings data)
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(DATA_KEY, json);
            PlayerPrefs.Save();
        }
    }
}