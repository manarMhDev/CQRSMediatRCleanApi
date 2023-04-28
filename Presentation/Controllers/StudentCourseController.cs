using Application.StudentCourse.Commands.AddCourseToStudent;
using Application.StudentCourse.Queries.GetAllCoursesOfStudent;
using Application.StudentCourse.Queries.GetAllStudentsIncourse;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentCourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseToStudent(AddCourseToStudentCommandRequest model)
        {
            AddStudentToCourseCommandValidator obj = new AddStudentToCourseCommandValidator();
            var result = obj.Validate(model);
            if (result.IsValid)
            {
                var studentCourse = await mediator.Send(new AddCourseToStudentCommand(
                model.StudentId, model.CourseId));
                // return studentCourse;
                return StatusCode(StatusCodes.Status200OK, studentCourse);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }
   
        [HttpGet]
        public async Task<List<GetAllStudentsInCourseResponse>> GetStudentsInCourseListAsync(int courseId)
        {
            var studentDetails = await mediator.Send(new GetAllStudentsInCourseQuery() { CourseId = courseId });

            return studentDetails;
        }
        [HttpGet]
        public async Task<List<GetAllCoursesOfStudentResponse>> GetCoursesOfStudentListAsync(int studentId)
        {
            var courseDetails = await mediator.Send(new GetAllCoursesOfStudentQuery() { StudentId = studentId });

            return courseDetails;
        }
    }
}
