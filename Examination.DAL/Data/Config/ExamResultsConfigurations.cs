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
    internal class ExamResultsConfigurations : IEntityTypeConfiguration<ExamResults>
    {
        public void Configure(EntityTypeBuilder<ExamResults> builder)
        {
            builder.HasOne(E => E.Exams)
                .WithMany(E => E.ExamResults)
                .HasForeignKey(E => E.ExamsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(E => E.QnAs)
                .WithMany(E => E.ExamResults)
                .HasForeignKey(E => E.QnAsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
