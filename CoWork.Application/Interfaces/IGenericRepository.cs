using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoWork.Application.Interfaces
{
    public interface IGenericRepository<TEntity, TKey>
       where TEntity : BaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<List<TResult>> QueryAsync<TResult>(
       Expression<Func<TEntity, bool>>? predicate = null,
       Expression<Func<TEntity, TResult>> selector = null!,
       Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
       bool asNoTracking = true);
        Task<TResult?> QuerySingleAsync<TResult>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TResult>> selector,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool asNoTracking = true);
    }
}
