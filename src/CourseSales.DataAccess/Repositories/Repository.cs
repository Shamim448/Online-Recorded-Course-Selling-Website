using CourseSales.DataAccess.Entities;
using CourseSales.DataAccess.Entities.Course;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _session.SaveAsync(entity);
            await _session.FlushAsync();
        }

        public async Task AddOrUpdateAsync(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
            await _session.FlushAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _session.Delete(entity);
            await _session.FlushAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _session.Update(entity);
            await _session.FlushAsync();
        }

        public async Task <IEnumerable<TEntity>> GetAllAsync()
        {
            var query = _session.Query<TEntity>().ToList();
            await _session.FlushAsync();
            return query.ToList();
        }
    }
}
