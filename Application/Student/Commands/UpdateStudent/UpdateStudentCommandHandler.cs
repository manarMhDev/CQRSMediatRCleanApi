using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Student.Commands.UpdateStudent
{
    class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<bool> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student =  _studentRepository.GetById(command.StudentId);
            if (student == null)
                return false;

            student.FirstName = command.FirstName;
            student.LastName = command.LastName;

            await _studentRepository.UpdateEntity(student);
            return true;
        }
    }
}