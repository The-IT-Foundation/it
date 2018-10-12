using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace it.core
{
    public class DataContextBase<T> : It<T> where T : It<T>, new()
    {
        public override Task<bool> CanSave()
        {
            throw new NotImplementedException();
        }
        
        public List<T> GetDataContext()
        {
            return new List<T>();
        }

        // repo fo' sho' needs to be part of this
        public virtual ARepositoryOf<T> Repository { get; }

        // but service? i feel like that should be provided by the interface of the domain entitty
        public virtual AServiceFor<T> Service { get; }
    }
}