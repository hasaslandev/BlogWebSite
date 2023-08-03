using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.DataAccess
{
    public interface IEntityRepository<T> where T : class/*, IEntity, new()*/
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>> filter);
        Task AddAsync(T entiy);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        T Find(Expression<Func<T, bool>> where);

        Task<T> GetbyIdAsync(int id);

    }
}
