using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Class to configure Property Image table with entity framework based on entity
    /// </summary>
    public class PropertyImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("tblPropertyImage");
            builder.HasKey(x => new { x.IdPropertyImage });

            builder.Property(x => x.File)
                .HasColumnName("File")
                .IsRequired(false);

            builder.Property(e => e.Enabled)
                .HasColumnName("Enabled");                

            builder.HasOne(x => x.Property)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.IdProperty);
        }
    }
}
