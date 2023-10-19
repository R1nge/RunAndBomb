using System.Threading.Tasks;

namespace Services.Factories
{
    public interface IUIFactory<T>
    {
        Task<T> Create();
    }
}