using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCourse.Commands.AddCourseToStudent
{
    public class AddCourseToStudentCommandRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
