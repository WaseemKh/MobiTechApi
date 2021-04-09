using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Data.Models.Config
{


    public class chequeConfig : IEntityTypeConfiguration<Cheque>
    {
        public void Configure(EntityTypeBuilder<Cheque> builder)
        {
            builder.ToTable("Sys_Cheque");
            builder.HasKey(k => k.Id);

            builder.HasOne(p => p.Customer)
              .WithMany(p => p.Customers)
              .HasForeignKey(key => key.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ChStatus)
             .WithMany(p => p.CheqStatus)
             .HasForeignKey(key => key.ChStatusId)
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
