using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Repositories
{
    public class StudentCourseRepository : RepositoryBase<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
