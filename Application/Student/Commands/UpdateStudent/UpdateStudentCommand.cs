using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UpdateStudentCommand(int sId,string fName, string lName)
        {
            StudentId = sId;
            FirstName = fName;
            LastName = lName;
        }
    }
}