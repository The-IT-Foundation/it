using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace it.core
{
    public abstract class ARepositoryOf<T> : It<T>, IEnumerable<T> where T : It<T>, new()
    {
        protected ARepositoryOf(List<T> dbSet)
        {
            _dbSet = dbSet;
        }

        // protected IDataContext GetContext() { } ??

        private readonly List<T> _dbSet;

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public IQueryable<T> Get()
        {
            return new EnumerableQuery<T>(_dbSet);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dbSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
    }
}