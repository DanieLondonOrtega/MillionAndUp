using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MillionAndUp.Infrastructure.DataAccess.Context
{
    public class EntityDbContext : DbContext
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the EntityDbContext/> class.
        /// </summary>     
        public EntityDbContext(
            DbContextOptions<EntityDbContext> dbContextOptions,
            IConfiguration configuration)
            : base(dbContextOptions)
        {
            _configuration = configuration;            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);            
        }
    }
}
