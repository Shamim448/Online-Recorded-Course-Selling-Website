using CourseSales.DataAccess.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Services.Features.Services
{
    public interface ICourseService
    {
        Task<Course> AddCourseAsync(string title, string description, decimal price, string thumbnailImage);
    }
}
