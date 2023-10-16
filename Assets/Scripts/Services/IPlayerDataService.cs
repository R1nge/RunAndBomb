using Data;

namespace Services
{
    public interface IPlayerDataService
    {
        void Save();
        PlayerStatisticsModel Load();
        PlayerStatisticsModel Model { get; }
    }
}