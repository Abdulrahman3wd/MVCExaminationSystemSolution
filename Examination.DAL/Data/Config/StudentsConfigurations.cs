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
    public class StudentsConfigurations : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.Property(S=>S.Name).IsRequired().HasMaxLength(50);
            builder.Property(S => S.UserName).IsRequired().HasMaxLength(50);
            builder.Property(S => S.Password).IsRequired().HasMaxLength(50);
            builder.Property(S => S.Contact).IsRequired().HasMaxLength(50);
            builder.Property(S => S.CvFileName).IsRequired().HasMaxLength(250);
            builder.Property(S => S.PictureName).IsRequired().HasMaxLength(250);

            builder.HasOne(D => D.Groups)
                .WithMany(P => P.Students)
                .HasForeignKey(D => D.GroupsId);


        }
    }
}
