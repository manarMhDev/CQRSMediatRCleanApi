using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateStudentCommand(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
    }
}
