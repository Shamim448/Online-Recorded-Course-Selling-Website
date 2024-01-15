using Autofac;
using CourseSales.Services.Features.Services;
using System.ComponentModel.DataAnnotations;

namespace CourseSales.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 100000.00, ErrorMessage = "Price should be between 0 and 100000.00")]
        public decimal Price { get; set; }

        [Display(Name = "Thumbnail Image")]
        public string? ThumbnailImage { get; set; }

        private ICourseService _courseService;

        public CourseCreateModel()
        {

        }

        public CourseCreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseService>();
        }

        internal async Task CreateCourseAsync()
        {
            await _courseService.AddCourseAsync(Title, Description, Price, ThumbnailImage);
        }
    }
}
