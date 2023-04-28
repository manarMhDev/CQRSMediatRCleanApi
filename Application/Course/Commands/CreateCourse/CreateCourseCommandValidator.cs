using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Course Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Course Description is required");


        }
    }
}
