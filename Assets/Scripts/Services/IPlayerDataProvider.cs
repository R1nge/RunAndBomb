using Data;

namespace Services
{
    public interface IPlayerDataProvider
    {
        public PlayerStatisticsModel Load();
        public void Save(PlayerStatisticsModel data);
    }
}