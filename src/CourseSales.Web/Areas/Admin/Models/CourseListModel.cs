using CourseSales.DataAccess.Entities.Course;
using CourseSales.Services.Features.Services;

namespace CourseSales.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        private readonly ICourseService _courseService;

        public CourseListModel()
        {
            
        }
        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task <IEnumerable<Course>> GetAllCourses()
        {
            var result = await _courseService.GetCourses();
            return result;
        }
    }
}
