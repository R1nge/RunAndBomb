using Data;

namespace Services.Data.Player
{
    public interface IPlayerDataProvider
    {
        public PlayerStatisticsModel Load();
        public void Save(PlayerStatisticsModel data);
    }
}