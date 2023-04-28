using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCourse.Queries.GetAllCoursesOfStudent
{
    public class GetAllCoursesOfStudentQuery : IRequest<List<GetAllCoursesOfStudentResponse>>
    {
        public int StudentId { get; set; }
    }
}
