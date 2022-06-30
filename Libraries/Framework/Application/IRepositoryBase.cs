using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Application
{
    public interface IRepositoryBase<TKey, T> where T : class
    {
        T Get(TKey id);
        void DeleteRecord(T obj);
        List<T> Get();
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
