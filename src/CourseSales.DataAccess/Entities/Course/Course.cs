using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.DataAccess.Entities.Course
{
    public class Course: IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }   
        public virtual string ThumbnailImage { get; set; }   
    }
}
