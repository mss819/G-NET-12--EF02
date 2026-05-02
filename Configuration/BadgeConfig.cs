using G_NET_12_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02.Configuration
{
    internal class BadgeConfig : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges").HasKey(b => b.id);
            builder.Property(b => b.id).ValueGeneratedOnAdd();
            builder.Property(b => b.Number).IsRequired();
            builder.Property(b => b.IssueDate).IsRequired();
            builder.Property(b => b.Tier).IsRequired().HasColumnType("nvarchar(100)");
           
        }
    }
}
