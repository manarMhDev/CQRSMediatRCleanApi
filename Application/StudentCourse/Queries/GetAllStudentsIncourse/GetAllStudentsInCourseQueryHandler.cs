using AutoMapper;
using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentCourse.Queries.GetAllStudentsIncourse
{
    public class GetAllStudentsInCourseQueryHandler : IRequestHandler<GetAllStudentsInCourseQuery, List<GetAllStudentsInCourseResponse>>
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsInCourseQueryHandler(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }
        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Entities.StudentCourse,GetAllStudentsInCourseResponse>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Student.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Student.LastName));
            });
        }
        public async Task<List<GetAllStudentsInCourseResponse>> Handle(GetAllStudentsInCourseQuery query, CancellationToken cancellationToken)
        {
            List<Domain.Entities.StudentCourse> result = _studentCourseRepository.SearchFor(x=>x.CourseId == query.CourseId, "Student,Course").OrderBy(x => x.StudentId).ToList();

            return await Task.FromResult(_mapper.Map<List<GetAllStudentsInCourseResponse>>(result));
        }
    }
}