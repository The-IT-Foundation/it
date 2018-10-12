using it.core.Interfaces;

namespace it.core
{
    public abstract class AServiceFor<T> : It<T> where T : It<T>, new()
    {
        protected static ARepositoryOf<T> Repository
        {
            get
            {
                var obj = new T() as IGetStored<T>;
                return obj?.Repository;
            }
        }
    }
}