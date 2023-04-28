using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.StudentId).NotNull().NotEmpty().WithMessage("StudentId  is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Student FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Student LastName is required");


        }
    }
}
