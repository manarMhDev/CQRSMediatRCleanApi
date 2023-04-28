using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Student.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Domain.Entities.Student()
            {
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            await _studentRepository.Insert(student);
            return student.StudentId;
        }
    }
}