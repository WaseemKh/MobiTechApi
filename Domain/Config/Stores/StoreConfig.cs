using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Store;

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
          
           builder.Property(u => u.ActiveNo).HasDefaultValue(45);
            builder.Property(u => u.StatusNo).HasDefaultValue(47);


            builder.HasOne(p => p.LkpType)
              .WithMany(p => p.LkpActives)
              .HasForeignKey(key => key.ActiveNo)
                .HasConstraintName("FK_Store_LkpTypeId")

              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.LkpColor)
                .WithMany(p => p.LkpColors)
                .HasForeignKey(key => key.ColorNo).IsRequired(false)
                .HasConstraintName("FK_Store_LkpColorId")

                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.LkpStatus)
                .WithMany(p => p.LkpStatus)
                .HasForeignKey(key => key.StatusNo).IsRequired(false)
                .HasConstraintName("FK_Store_StatusId")

                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.LkpStorage)
                .WithMany(p => p.LkpStorages)
                .HasForeignKey(key => key.StorgeNo).IsRequired(false)
                .HasConstraintName("FK_Store_StorageId")

                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(p => p.LkpActive)
                .WithMany(p => p.LkpActives)
                .HasForeignKey(key => key.ActiveNo).IsRequired(true)
                .HasConstraintName("FK_Store_ActivesId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Ram)
                .WithMany(p => p.Rams)
                

                .HasForeignKey(key => key.RamNo).IsRequired(false)
                .HasConstraintName("FK_Store_Rams")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
