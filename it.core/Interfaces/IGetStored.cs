using System.Collections.Generic;

namespace it.core.Interfaces
{
    public interface IGetStored<T> where T : It<T>, new()
    {
        ARepositoryOf<T> Repository { get; }

        List<T> GetDataContext();
    }
}