using System;
using System.Threading.Tasks;
using Services.Data;

namespace Services
{
    public class AsyncPlaceHolderLoadingOperation : IAsyncLoadingOperation
    {
        void ILoadingOperation.Load()
        {
        }

        Task IAsyncLoadingOperation.Load() => Task.Delay(TimeSpan.FromSeconds(2));
    }
}