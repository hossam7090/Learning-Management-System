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
    public class Ins_SubjectConfigurations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder
                .HasKey(x => new { x.SubId, x.InsId });


            builder.HasOne(ds => ds.instructor)
                     .WithMany(d => d.Ins_Subjects)
                     .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.Ins_Subjects)
                 .HasForeignKey(ds => ds.SubId);

        }

    }
}
