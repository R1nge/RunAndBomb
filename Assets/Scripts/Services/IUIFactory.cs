namespace Services
{
    public interface IUIFactory<T>
    {
        T Create();
    }
}