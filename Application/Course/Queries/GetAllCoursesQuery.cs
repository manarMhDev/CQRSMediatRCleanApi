using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Queries
{
    public class GetAllCoursesQuery : IRequest<List<Domain.Entities.Course>>
    {
    }
}
