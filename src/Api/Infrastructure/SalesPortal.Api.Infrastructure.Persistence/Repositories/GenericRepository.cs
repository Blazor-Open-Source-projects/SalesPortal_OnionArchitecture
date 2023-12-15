using Microsoft.EntityFrameworkCore;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Domain.Models;
using System.Linq.Expressions;

namespace SalesPortal.Api.Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext _context;
    public GenericRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    protected DbSet<TEntity> entity => _context.Set<TEntity>();


    #region Add Operations
    public virtual int Add(TEntity entity)
    {
        this.entity.Add(entity);   
        return _context.SaveChanges();
    }

    public virtual async Task<int> AddAsync(TEntity entity)
    {
        await this.entity.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    #endregion


    #region Delete Operations

    public virtual int Delete(Guid id)
    {
        var entity = this.entity.Find(id);
        return Delete(entity);
    }

    public virtual int Delete(TEntity entity)
    {
        if(_context.Entry(entity).State == EntityState.Detached)
        {
            this.entity.Attach(entity);
        }
        this.entity.Remove(entity);

        return _context.SaveChanges();
    }

    public virtual async Task<int> DeleteAsync(Guid id)
    {
        var entity =await this.entity.FindAsync(id);
        return await DeleteAsync(entity);
    }

    public virtual Task<int> DeleteAsync(TEntity entity)
    {
        if(_context.Entry(entity).State == EntityState.Detached)
        {
            this.entity.Attach(entity);
        }
        this.entity.Remove(entity);

        return _context.SaveChangesAsync();
    }

    #endregion


    #region Get Operations
    public virtual async Task<TEntity> GetByIdAsync(Guid Id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
    {
        TEntity found = this.entity.Find(Id);

        if (found == null)
            return null;

        if(noTracking)
            _context.Entry(found).State = EntityState.Detached;
        foreach (var include in includes)
        {
            _context.Entry(found).Reference(include).Load();

        }


        return found;
                
                
    }
    public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = entity.AsQueryable();  
        if(predicate != null)
            query = query.Where(predicate);

        query = ApplyIncludes(query, includes);
 
        if (noTracking)
            query.AsNoTracking();

        return await query.SingleOrDefaultAsync();
    }
    #endregion


    #region Update Operations
    public virtual int Update(TEntity entity)
    {
        this.entity.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified; 
        return _context.SaveChanges();  
    }

    public virtual Task<int> UpdateAsync(TEntity entity)
    {
        this.entity.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return _context.SaveChangesAsync();
    }

    #endregion


    #region GetAll Operations
    public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool noTracking = true) { 

        IQueryable<TEntity> query = entity;

        if (predicate != null)
        {
            query = query.Where(predicate);

        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (noTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync();

    }
    #endregion


    public virtual IQueryable<TEntity> AsQueryable()
    {
        var query = entity.AsQueryable();
        return query;
    }
    private IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
    {
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

        }

        return query;
    }
}
