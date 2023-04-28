using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentCourse.Commands.AddCourseToStudent
{
    class AddCourseToStudentCommandHandler : IRequestHandler<AddCourseToStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;

        public AddCourseToStudentCommandHandler(IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IStudentCourseRepository studentCourseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;
        }
        public async Task<bool> Handle(AddCourseToStudentCommand command, CancellationToken cancellationToken)
        {
            var student = _studentRepository.GetById(command.StudentId);
            var course = _courseRepository.GetById(command.CourseId);
            if (student == null)
                return false;

            if (course == null)
                return false;
            var studentCourse = new Domain.Entities.StudentCourse
            {
                 StudentId = student.StudentId,
                 CourseId = course.CourseId
            };
            await _studentCourseRepository.Insert(studentCourse);
            return true;
        }
    }
}