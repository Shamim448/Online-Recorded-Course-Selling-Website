using CourseSales.DataAccess.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.Repositories
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {

    }
}
