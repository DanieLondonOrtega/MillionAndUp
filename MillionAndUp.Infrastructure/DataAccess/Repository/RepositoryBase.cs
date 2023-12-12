using Microsoft.EntityFrameworkCore;
using MillionAndUp.Infrastructure.DataAccess.Context;
using System.Linq.Expressions;

namespace MillionAndUp.Infrastructure.DataAccess.Repository
{
    /// <summary>
    /// Generic base class with the basic methods to be used by any service
    /// </summary>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// The dbcontext
        /// </summary>
        private readonly EntityDbContext _dataContext;

        /// <summary>
        /// The entities general
        /// </summary>
        private readonly DbSet<TEntity> _entities;
        public RepositoryBase(EntityDbContext dataContext)
        {
            _dataContext = dataContext;
            _entities = dataContext.Set<TEntity>();
        }
        public bool Add(TEntity entity)
        {
            _entities.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public bool Delete(object id)
        {
            TEntity entityDelete = _entities.Find(id);
            if (entityDelete != null)
            {
                _entities.Remove(entityDelete);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(string usuario)
        {
            TEntity entityDelete = _entities.Find(usuario);
            if (entityDelete != null)
            {
                _entities.Remove(entityDelete);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }
        public bool Update(TEntity entity)
        {
            _entities.Update(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _entities.AsQueryable();
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await GetAll();
            query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault(where);
        }

        public void Clear()
        {
            _dataContext.ChangeTracker.Clear();
        }
    }
}
