using MillionAndUp.Infrastructure.DataAccess.Context;

namespace MillionAndUp.Infrastructure.DataAccess.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly IDataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactory" /> class.
        /// </summary>
        public RepositoryFactory(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IRepositoryBase<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new RepositoryBase<TEntity>(this.dataContext);
        }
    }
}
