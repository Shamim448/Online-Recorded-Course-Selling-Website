using CourseSales.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.Repositories
{
    public interface IRepository<TEntity, in TKey>
    where TEntity : class, IEntity<TKey>
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task AddOrUpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
