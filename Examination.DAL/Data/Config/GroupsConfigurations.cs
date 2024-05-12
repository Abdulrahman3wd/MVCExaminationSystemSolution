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
    public class GroupsConfigurations : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.Property(G => G.Name).IsRequired().HasMaxLength(100);
            builder.Property(G=>G.Description).HasMaxLength(250);
            builder.HasOne(G=>G.Users)
                .WithMany(G => G.Groups)
                .HasForeignKey(F=>F.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
