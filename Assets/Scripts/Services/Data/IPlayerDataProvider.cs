using Data;

namespace Services.Data
{
    public interface IPlayerDataProvider
    {
        public PlayerStatisticsModel Load();
        public void Save(PlayerStatisticsModel data);
    }
}