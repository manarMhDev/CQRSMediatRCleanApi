using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Student.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Domain.Entities.Student>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Domain.Entities.Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            Domain.Entities.Student result = _studentRepository.SearchFor(x => x.StudentId == query.StudentId).FirstOrDefault();
            return await Task.FromResult(result);
        }
    }
}