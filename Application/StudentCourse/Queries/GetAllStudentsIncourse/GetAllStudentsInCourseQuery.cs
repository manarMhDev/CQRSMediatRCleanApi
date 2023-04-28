using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCourse.Queries.GetAllStudentsIncourse
{
    public  class GetAllStudentsInCourseQuery : IRequest<List<GetAllStudentsInCourseResponse>>
    {
        public int CourseId { get; set; }
    }
}
