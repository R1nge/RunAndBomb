using System;
using System.Threading.Tasks;
using Services.Data;

namespace Services
{
    public class AsyncPlaceHolderLoadingOperation : IAsyncLoadingOperation
    {
        Task IAsyncLoadingOperation.Load() => Task.Delay(0);
    }
}