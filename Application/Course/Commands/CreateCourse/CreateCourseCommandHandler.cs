using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Course.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<int> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var course = new Domain.Entities.Course()
            {
                Title = command.Title,
                Description = command.Description
            };
            await _courseRepository.Insert(course);
            return course.CourseId;
        }
    }
}