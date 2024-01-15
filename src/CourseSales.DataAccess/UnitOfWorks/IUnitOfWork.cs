using CourseSales.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
        ICourseRepository Courses { get; }
        void Save();
    }
}
