using it.core.Interfaces;

namespace it.core
{
    public interface IAmADtoFor<T> where T : It<T>, IAmAnEntity, new()
    {
        // common methods? 
    }
}