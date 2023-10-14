using System;

namespace Data
{
    [Serializable]
    public class PlayerStatisticsModel
    {
        public int Level { get; set; }

        public PlayerStatisticsModel(int level)
        {
            Level = level;
        }
    }
}