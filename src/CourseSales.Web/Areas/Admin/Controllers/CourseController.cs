using Autofac;
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


        public CourseController(ILifetimeScope scope, ILogger<CourseController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = _scope.Resolve<CourseCreateModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.CreateCourseAsync();
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);                  
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error"); 
                }
            }
            return View(nameof(Index));
        }
    }
}