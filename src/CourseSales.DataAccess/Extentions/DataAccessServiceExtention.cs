using CourseSales.DataAccess.Repositories;
using CourseSales.DataAccess.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace CourseSales.DataAccess.Extentions
{
    public static class DataAccessServiceExtention
    {
        public static IServiceCollection DataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddNHibernateContext(connectionString);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICourseRepository, CourseRepository>();

            return services;
        }
    }
}
