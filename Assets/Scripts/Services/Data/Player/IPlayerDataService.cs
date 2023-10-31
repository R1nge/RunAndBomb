using Data;

namespace Services.Data.Player
{
    //TODO: can rid of it???
    public interface IPlayerDataService
    {
        void Save();
        void Load();
        PlayerStatisticsModel Model { get; }
    }
}