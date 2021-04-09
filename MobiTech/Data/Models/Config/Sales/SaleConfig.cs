using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Data.Models.Config
{
    public class SaleConfig:IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sys_Customer");
            builder.HasKey(k => k.Id);
            builder.Property(u => u.IMEI).IsRequired();
            builder.HasIndex(u => u.IMEI).IsUnique();

            builder.HasOne(p => p.LkpMethod)
              .WithMany(p => p.Methode)
              .HasForeignKey(key => key.LkpMethodId)
              .OnDelete(DeleteBehavior.Cascade);

           
        }
    }
}
