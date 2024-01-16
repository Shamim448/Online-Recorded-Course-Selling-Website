using Autofac;
using CourseSales.DataAccess.Entities.Course;
using CourseSales.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CourseSales.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        ILifetimeScope _scope;
        ILogger<CourseController> _logger;
        IWebHostEnvironment _webHostEnvironment;

        public CourseController(ILifetimeScope scope, ILogger<CourseController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _scope = scope;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var model =  _scope.Resolve<CourseListModel>();
            IEnumerable<Course>? result = await model.GetAllCourses();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var model = _scope.Resolve<CourseCreateModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model, IFormFile? file)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {

                try
                {   
                    if(file != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(wwwRootPath, @"images\course");

                        var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                        
                            file.CopyTo(fileStream);
                            fileStream.Dispose();


                        model.ThumbnailImage = @"images\course\" + fileName;
                    }
                    await model.CreateCourseAsync();
                    TempData["success"] = "Create Course Succesfully";
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["warning"] = "Already has this course";
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData["error"] = "Course creation failed";
                }
            }
            return View(nameof(Index));
        }
    }
}