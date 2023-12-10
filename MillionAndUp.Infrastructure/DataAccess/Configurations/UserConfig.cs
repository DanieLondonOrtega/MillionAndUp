using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MillionAndUp.Domain.Entities;

namespace MillionAndUp.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Class to configure User table with entity framework based on entity
    /// </summary>
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tblUser");
            builder.HasKey(x => x.Usuario);

            builder.Property(x => x.Usuario)
                .HasColumnName("Usuario")
                .HasMaxLength(15)
                .IsRequired(true);

            builder.Property(x => x.Password)    
                .HasColumnName("Password")                
                .IsRequired(true);
        }
    }
}
