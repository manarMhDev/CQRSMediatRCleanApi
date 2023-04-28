using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Configurations
{
    public class CourseMap
    {
        public CourseMap(EntityTypeBuilder<Course> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CourseId);
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.Description).IsRequired();
         
        }
    }
}
