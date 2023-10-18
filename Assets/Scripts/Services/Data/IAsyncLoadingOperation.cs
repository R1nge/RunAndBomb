using System.Threading.Tasks;

namespace Services.Data
{
    public interface IAsyncLoadingOperation
    {
        Task Load();
    }
}