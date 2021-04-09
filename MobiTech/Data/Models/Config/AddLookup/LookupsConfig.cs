
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobiTech.Data.Models.Config
{
    public class LookupsConfig : IEntityTypeConfiguration<Lokups>
    {
        public void Configure(EntityTypeBuilder<Lokups> builder)

        {
            builder.ToTable("Lokups");
            builder.HasKey(k => k.Id);
            builder.Property(u => u.Name).IsRequired();

            builder.HasOne(p => p.Type)
              .WithMany(p =>p.Types)
              .HasForeignKey(key => key.TypeId).IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);

        }
        }
}
