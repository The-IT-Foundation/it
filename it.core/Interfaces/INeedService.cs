namespace it.core.Interfaces
{
    public interface INeedService<T> where T : It<T>, new()
    {
        // but service? i feel like that should be provided by the interface of the domain entitty
        AServiceFor<T> Service { get; }
    }
}