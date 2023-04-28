using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Configurations
{
   public  class StudentCourseMap
    {
        public StudentCourseMap(EntityTypeBuilder<StudentCourse> entityBuilder)
        {
            entityBuilder.HasKey(sc => new { sc.StudentId, sc.CourseId });
            entityBuilder
            .HasOne(t => t.Student)
            .WithMany(t => t.StudentCourse)
            .HasForeignKey(t => t.StudentId);

            entityBuilder
            .HasOne(t => t.Course)
            .WithMany(t => t.StudentCourse)
             .HasForeignKey(t => t.CourseId);

        }
    }
}
