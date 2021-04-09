using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobiTech.Data.Models.Model;

namespace MobiTech.Data.Models.Config
{
    public class LkpTypeConfig : IEntityTypeConfiguration<LkpType>
    {
        public void Configure(EntityTypeBuilder<LkpType> builder)

        {
            builder.ToTable("Lkp_Type");
            builder.HasKey(k => k.Id);
            builder.Property(u => u.Name).IsRequired();
          


            
        }
    }
}
