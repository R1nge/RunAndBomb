using System.Threading.Tasks;

namespace Services
{
    public interface IAsyncLoadingOperation : ILoadingOperation
    {
        new Task Load();
    }
}