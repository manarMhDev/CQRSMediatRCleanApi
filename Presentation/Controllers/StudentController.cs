
using Application.Student.Commands.CreateStudent;
using Application.Student.Commands.UpdateStudent;
using Application.Student.Queries.GetAllStudents;
using Application.Student.Queries.GetStudentById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<Domain.Entities.Student> GetStudentByIdAsync(int studentId)
        {
           
            var studentDetails = await mediator.Send(new GetStudentByIdQuery() { StudentId = studentId });

            return studentDetails;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(CreateStudentRequest studentDetails)
        {
            CreateStudentCommandValidator obj = new CreateStudentCommandValidator();
            var result = obj.Validate(studentDetails);
            if (result.IsValid)
            {
                var studentDetail = await mediator.Send(new CreateStudentCommand(
                             studentDetails.FirstName, studentDetails.LastName));
               // return studentDetail;
                return StatusCode(StatusCodes.Status200OK, studentDetail);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(UpdateStudentRequest studentDetails)
        {
            UpdateStudentCommandValidator obj = new UpdateStudentCommandValidator();
            var result = obj.Validate(studentDetails);
            if (result.IsValid)
            {
                var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(
         studentDetails.StudentId,
         studentDetails.FirstName,
         studentDetails.LastName));
              //  return isStudentDetailUpdated;
                return StatusCode(StatusCodes.Status200OK, isStudentDetailUpdated);
            }
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }
        [HttpGet]
        public async Task<List<Domain.Entities.Student>> GetStudentListAsync()
        {
            var studentDetails = await mediator.Send(new GetAllStudentsQuery());

            return studentDetails;
        }

     
    }
}
