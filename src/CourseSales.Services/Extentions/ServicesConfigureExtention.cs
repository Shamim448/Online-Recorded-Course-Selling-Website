using CourseSales.Services.Features.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Services.Extentions
{
    public static class ServicesConfigureExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<ICourseService, CourseService>();
            return services;
        }
    }
}
