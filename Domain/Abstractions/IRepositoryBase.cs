using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate = null, string Include = null);
        T GetById(int id);
        Task<T> Insert(T entity);
        void Delete(T entity);
        Task UpdateEntity(T entity);
    }
}
