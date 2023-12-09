using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Class to configure Property Trace table with entity framework based on entity
    /// </summary>
    public class PropertyTraceConfig : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("tblPropertyTrace");
            builder.HasKey(x => new { x.IdPropertyTrace, x.IdProperty });

            builder.Property(x => x.DateSale)
                .HasColumnName("DateSale")
                .IsRequired(true);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Value)
                .HasColumnName("Value")
                .HasPrecision(18,2)
                .IsRequired(true);

            builder.Property(x => x.Tax)
                .HasColumnName("Tax")
                .HasPrecision(18, 2)
                .IsRequired(true);

            builder.HasOne(x => x.Property)
                .WithMany(x => x.Traces)
                .HasForeignKey(x => x.IdProperty);
        }
    }
}
