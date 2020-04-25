using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);


    }
}
