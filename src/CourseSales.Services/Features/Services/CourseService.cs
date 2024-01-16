using CourseSales.DataAccess.Entities.Course;
using CourseSales.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Services.Features.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;


        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Course> AddCourseAsync(string title, string description, decimal price, string thumbnailImage)
        {
            Course course = new Course()
            {
                Title = title,
                Description = description,
                Price = price,
                ThumbnailImage = thumbnailImage,
            };

            await _unitOfWork.BeginTransaction();
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.Commit();

            return course;
        }

        public async Task <IEnumerable<Course>> GetCourses()
        {
            //await _unitOfWork.BeginTransaction();
            return await _unitOfWork.Courses.GetAllAsync();
        }

        
    }
}