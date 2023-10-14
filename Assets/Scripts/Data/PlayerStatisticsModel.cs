using System;

namespace Data
{
    [Serializable]
    public class PlayerStatisticsModel
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public PlayerStatisticsModel(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}