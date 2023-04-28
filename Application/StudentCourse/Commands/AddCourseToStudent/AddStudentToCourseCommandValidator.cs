using Domain.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentCourse.Commands.AddCourseToStudent
{
    public class AddStudentToCourseCommandValidator : AbstractValidator<AddCourseToStudentCommandRequest>
    {
        public AddStudentToCourseCommandValidator()
        {
            RuleFor(x => x.StudentId).NotNull().NotEmpty().WithMessage("StudentId is required");
            RuleFor(x => x.CourseId).NotNull().NotEmpty().WithMessage("CourseId is required");
          
        }
    
    }
}
