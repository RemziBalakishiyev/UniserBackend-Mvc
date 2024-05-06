using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGeneric<T> where T: class , ITable, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        Task<bool> Contains(T entity);
        bool Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression);
        Task SaveChangesAsync();
    }
}
