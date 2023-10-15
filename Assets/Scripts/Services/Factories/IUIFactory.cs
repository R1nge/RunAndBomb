namespace Services.Factories
{
    public interface IUIFactory<T>
    {
        T Create();
    }
}