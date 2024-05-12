using Examination.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Data.Config
{
    public class ExamsConfigurations : IEntityTypeConfiguration<Exams>
    {
        public void Configure(EntityTypeBuilder<Exams> builder)
        {
            builder.Property(E => E.Title).IsRequired().HasMaxLength(100);
            builder.Property(E=>E.Description).HasMaxLength(250);
            builder.HasOne(e => e.Groups)
                .WithMany(e=>e.Exams)
                .HasForeignKey(e=>e.GroupsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
