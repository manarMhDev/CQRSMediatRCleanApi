using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Commands.UpdateCourse
{
    public class UpdateCourseRequest
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
