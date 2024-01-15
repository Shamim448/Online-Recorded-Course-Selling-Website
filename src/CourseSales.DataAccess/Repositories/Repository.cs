using CourseSales.DataAccess.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task AddAsync(T entity)
        {
            await _session.SaveAsync(entity);
            await _session.FlushAsync();
        }

        public async Task AddOrUpdateAsync(T entity)
        {
            _session.SaveOrUpdate(entity);
            await _session.FlushAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _session.Delete(entity);
            await _session.FlushAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _session.Update(entity);
            await _session.FlushAsync();
        }
    }
}
