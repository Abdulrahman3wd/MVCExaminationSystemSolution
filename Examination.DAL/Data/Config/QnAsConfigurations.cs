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
    public class QnAsConfigurations : IEntityTypeConfiguration<QnAs>
    {
        public void Configure(EntityTypeBuilder<QnAs> builder)
        {
            builder.Property(Q => Q.Question).IsRequired();
            builder.Property(Q => Q.Answer).IsRequired();
            builder.Property(A => A.Option1).IsRequired().HasMaxLength(100);
            builder.Property(A => A.Option2).IsRequired().HasMaxLength(100);
            builder.Property(A => A.Option3).IsRequired().HasMaxLength(100);
            builder.Property(A => A.Option4).IsRequired().HasMaxLength(100);

            builder.HasOne(D => D.Exams)
                .WithMany(P => P.QnAs)
                .HasForeignKey(F => F.ExamsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
