using NHibernate.Type;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using CourseSales.DataAccess.Entities.Course;
namespace CourseSales.DataAccess.Mappings
{
    public class CourseMap : ClassMapping<Course>
    {
        public CourseMap()
        {
            Schema("dbo");
            Table("Courses");
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });
            Property(b => b.Title, x =>
            {
                x.Length(256);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
                x.Column("Title");
            });
            Property(b => b.Description, x =>
            {
                x.Length(5000);
                x.Type(NHibernateUtil.StringClob);
                x.Column("Description");
            });
            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Decimal);
                x.NotNullable(false);
                x.Column("Price");
            });
            Property(b => b.ThumbnailImage, x =>
            {
                x.Length(256);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(false);
                x.Column("ThumbnailImage");
            });
        }
    }

}
