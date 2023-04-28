using Application.Course.Commands.CreateCourse;
using Application.Course.Commands.UpdateCourse;
using Application.Course.Queries;
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
    public class CourseController : ControllerBase
    {
        private readonly IMediator mediator;
        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(CreateCourseRequest courseDetails)
        {
            CreateCourseCommandValidator obj = new CreateCourseCommandValidator();
            var result = obj.Validate(courseDetails);
            if (result.IsValid)
            {
                var courseDetail = await mediator.Send(new CreateCourseCommand(
                courseDetails.Title, courseDetails.Description));
                //   return courseDetail;
                return StatusCode(StatusCodes.Status200OK, courseDetail);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourseAsync(UpdateCourseRequest courseDetails)
        {
            UpdateCourseCommandValidator obj = new UpdateCourseCommandValidator();
            var result = obj.Validate(courseDetails);
            if (result.IsValid)
            {
                var isCourseDetailUpdated = await mediator.Send(new UpdateCourseCommand(
               courseDetails.CourseId,
               courseDetails.Title,
               courseDetails.Description));
                //  return isCourseDetailUpdated;
                return StatusCode(StatusCodes.Status200OK, isCourseDetailUpdated);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }
        [HttpGet]
        public async Task<List<Domain.Entities.Course>> GetCourseListAsync()
        {
            var courseDetails = await mediator.Send(new GetAllCoursesQuery());

            return courseDetails;
        }

      
    }
}
