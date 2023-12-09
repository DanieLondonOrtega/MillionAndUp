using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Class to configure Owner table with entity framework based on entity
    /// </summary>
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("tblOwner");
            builder.HasKey(x => x.IdOwner);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Photo)
                .HasColumnName("Photo")
                .IsRequired(false);

            builder.Property(x => x.Birthday)
                .HasColumnName("Birthday")
                .IsRequired(true);

            builder.HasMany(x => x.Properties)
                .WithOne(x => x.Owner);
        }
    }
}
