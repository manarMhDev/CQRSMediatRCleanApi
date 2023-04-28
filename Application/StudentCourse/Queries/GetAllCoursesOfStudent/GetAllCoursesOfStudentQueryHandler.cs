using AutoMapper;
using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentCourse.Queries.GetAllCoursesOfStudent
{
    class GetAllCoursesOfStudentQueryHandler : IRequestHandler<GetAllCoursesOfStudentQuery, List<GetAllCoursesOfStudentResponse>>
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public GetAllCoursesOfStudentQueryHandler(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }
        private MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Entities.StudentCourse, GetAllCoursesOfStudentResponse>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Course.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Course.Description));
            });
        }
        public async Task<List<GetAllCoursesOfStudentResponse>> Handle(GetAllCoursesOfStudentQuery query, CancellationToken cancellationToken)
        {
            List<Domain.Entities.StudentCourse> result = _studentCourseRepository.SearchFor(x => x.StudentId == query.StudentId, "Student,Course").OrderBy(x => x.StudentId).ToList();

            return await Task.FromResult(_mapper.Map<List<GetAllCoursesOfStudentResponse>>(result));
        }
    }
}