using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<Domain.Entities.Student>>
    {
    }
}
