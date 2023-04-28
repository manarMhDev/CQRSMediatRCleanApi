using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Student.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Domain.Entities.Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Domain.Entities.Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Student> result = _studentRepository.SearchFor().OrderBy(x => x.StudentId).ToList();
            return await Task.FromResult(result);
        }
    }
}