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
    internal class UsersConfigurations : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(E => E.Name).IsRequired().HasMaxLength(50);
            builder.Property(E => E.UserName).IsRequired().HasMaxLength(50);
            builder.Property(E => E.Password).IsRequired().HasMaxLength(50);

        }
    }
}
