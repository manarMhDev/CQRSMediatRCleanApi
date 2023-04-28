using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.CourseId).NotNull().NotEmpty().WithMessage("CourseId  is required");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Course Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Course Description is required");


        }
    }
}
