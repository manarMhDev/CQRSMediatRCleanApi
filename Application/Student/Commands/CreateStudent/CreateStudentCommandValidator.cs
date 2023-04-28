using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Student FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Student LastName is required");
           

        }
    }
}
