using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<bool> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            var course = _courseRepository.GetById(command.CourseId);
            if (course == null)
                return false;

            course.Title = command.Title;
            course.Description = command.Description;

            await _courseRepository.UpdateEntity(course);
            return true;
        }
    }
}