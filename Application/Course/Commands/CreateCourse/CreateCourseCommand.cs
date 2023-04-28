using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateCourseCommand(string title, string desc)
        {
            Title = title;
            Description = desc;
        }
    }
}
