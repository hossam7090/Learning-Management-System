using Lms.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Configurations
{

    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(x => x.DID);
            builder.Property(x => x.DNameAr).HasMaxLength(500);

            builder.HasMany(x => x.Students)
                  .WithOne(x => x.Department)
                  .HasForeignKey(x => x.DID)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Instructor)
            .WithOne(x => x.departmentManager)
            .HasForeignKey<Department>(x => x.InsManager)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}