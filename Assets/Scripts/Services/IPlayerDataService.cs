using Data;

namespace Services
{
    public interface IPlayerDataService
    {
        void Save();
        void Load();
        PlayerStatisticsModel Model { get; }
    }
}