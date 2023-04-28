using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public UpdateCourseCommand(int cId, string title, string desc)
        {
            CourseId = cId;
            Title = title;
            Description = desc;
        }
    }
}