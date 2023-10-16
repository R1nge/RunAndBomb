using System.Threading.Tasks;

namespace Services.Data
{
    public interface IAsyncLoadingOperation : ILoadingOperation
    {
        new Task Load();
    }
}