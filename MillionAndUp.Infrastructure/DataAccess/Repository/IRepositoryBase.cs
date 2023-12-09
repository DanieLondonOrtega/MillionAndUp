using System.Linq.Expressions;

namespace MillionAndUp.Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Generic base interface to implement on repository Base
    /// </summary>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        bool Add (TEntity entity);
        bool Update (TEntity entity);
        bool Delete (object id);
        Task<IQueryable<TEntity>> GetAll ();
        Task<TEntity> GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
