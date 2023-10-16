using Data;

namespace Services.Data
{
    public interface IPlayerDataService
    {
        void Save();
        void Load();
        PlayerStatisticsModel Model { get; }
    }
}