using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using MobiTech.Data.Models.Model;

namespace MobiTech.Data.Models.Config
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)

        {
            builder.ToTable("Sys_Store");
            builder.HasKey(k => k.Id);
            builder.Property(u => u.IMEI).IsRequired();
            builder.HasIndex(u => u.IMEI).IsUnique();
           
          // builder.Property(u => u.LkpActiveId).HasDefaultValue(45);
            builder.Property(u => u.LkpStatusId).HasDefaultValue(47);


            builder.HasOne(p => p.LkpType)
              .WithMany(p => p.LkpTypes)
              .HasForeignKey(key => key.LkpTypeId)
            // .HasConstraintName("FK_Store_LkpTypeId1")
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.LkpColor)
                .WithMany(p => p.LkpColors)
                .HasForeignKey(key => key.LkpColorId).IsRequired(false)
            // .HasConstraintName("FK_Store_ColorId1")

             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.LkpStatus)
                .WithMany(p => p.LkpStatuss)
                .HasForeignKey(key => key.LkpStatusId).IsRequired(false)
           // .HasConstraintName("FK_Stors_lokups_LkpStatusId")
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.LkpStorage)
                .WithMany(p => p.LkpStorages)
                .HasForeignKey(key => key.LkpStorageId).IsRequired(false)
            // .HasConstraintName("FK_Store_StorageId1")
             .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(p => p.LkpActive)
                .WithMany(p => p.LkpActives)
                .HasForeignKey(key => key.LkpActiveId).IsRequired(true)
            // .HasConstraintName("FK_Store_ActivesId1");

             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.LkpRam)
                .WithMany(p => p.Rams)
                .HasForeignKey(key => key.LkpRamId).IsRequired(false)
               // .HasConstraintName("FK_Store_RamId1")

               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
