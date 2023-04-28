using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Course.Queries
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<Domain.Entities.Course>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Domain.Entities.Course>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Course> result = _courseRepository.SearchFor().OrderBy(x => x.CourseId).ToList();
            return await Task.FromResult(result);
        }
    }
}