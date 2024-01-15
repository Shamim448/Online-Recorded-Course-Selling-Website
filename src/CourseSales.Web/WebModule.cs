using Autofac;
using CourseSales.Web.Areas.Admin.Models;

namespace CourseSales.Web
{
    public class WebModule : Module
    {
        public WebModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseCreateModel>().AsSelf();
            base.Load(builder);
        }
    }
}
