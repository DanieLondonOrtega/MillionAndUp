using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Class to configure Property table with entity framework based on entity
    /// </summary>
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("tblProperty");
            builder.HasKey(x => x.IdProperty);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Price)
                .HasColumnName("Price")
                .HasPrecision(18,2)
                .IsRequired(true);

            builder.Property(x => x.CodeInternal)
                .HasColumnName("CodeInternal")
                .HasMaxLength(5)
                .IsRequired(true);

            builder.Property(x => x.Year)
                .HasColumnName("Year")
                .IsRequired(true);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.IdOwner);

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Property);

            builder.HasMany(x => x.Traces)
                .WithOne(x => x.Property);
        }
    }
}
