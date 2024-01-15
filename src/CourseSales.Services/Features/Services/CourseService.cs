using CourseSales.DataAccess.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Services.Features.Services
{
    public class CourseService : ICourseService
    {
        public CourseService() { }
        public IList<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
