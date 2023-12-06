using SalesPortal.Api.Domain.Models;
using System.Linq.Expressions;

namespace SalesPortal.Api.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity 
{

    #region Add
    Task<int> AddAsync(TEntity entity);
    int Add(TEntity entity);
    #endregion

    #region Update

    Task<int> UpdateAsync(TEntity entity);
    int Update(TEntity entity);
    #endregion

    #region Delete 

    Task<int> DeleteAsync(Guid id);
    Task<int> DeleteAsync(TEntity entity);

    int Delete(Guid id);
    int Delete(TEntity entity);
    #endregion


    IQueryable<TEntity> AsQueryable();


    Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool noTracking = true);

    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetByIdAsync(Guid Id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
}
