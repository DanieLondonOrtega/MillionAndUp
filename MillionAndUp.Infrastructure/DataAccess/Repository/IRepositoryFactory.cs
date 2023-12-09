namespace MillionAndUp.Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// The repository factory.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>
        /// The repository.
        /// </returns>
        IRepositoryBase<TEntity> CreateRepository<TEntity>()
            where TEntity : class;
    }
}
