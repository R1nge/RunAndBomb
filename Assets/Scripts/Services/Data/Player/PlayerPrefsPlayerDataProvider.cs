using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.Data.Player
{
    public class PlayerPrefsPlayerDataProvider : IPlayerDataProvider
    {
        private const string DATA_KEY = "PlayerData";

        public PlayerStatisticsModel Load()
        {
            PlayerStatisticsModel data;

            string json = PlayerPrefs.GetString(DATA_KEY);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Data doesn't exist. Creating a new one");
                data = new PlayerStatisticsModel("NoName", 1);
            }
            else
            {
                data = JsonConvert.DeserializeObject<PlayerStatisticsModel>(json);
            }

            return data;
        }

        public void Save(PlayerStatisticsModel data)
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(DATA_KEY, json);
            PlayerPrefs.Save();
        }
    }
}