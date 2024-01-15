using CourseSales.DataAccess.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private readonly ICourseRepository _courseRepository;

        public UnitOfWork(ISession session,
            ICourseRepository courseRepository)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
            _courseRepository = courseRepository;
        }
        public async Task BeginTransaction()
        {
            await Task.Run(() => _transaction.Begin());
        }

        public async Task Commit()
        {
            await Task.Run(() => _transaction.Commit());
        }

        public async Task Rollback()
        {
            await Task.Run(() => _transaction.Rollback());
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _session.Dispose();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public ICourseRepository Courses => _courseRepository;

    }
}
