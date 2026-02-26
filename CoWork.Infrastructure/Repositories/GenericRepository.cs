using CoWork.Application.Interfaces;
using CoWork.Domain.Common;
using CoWork.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoWork.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> :
        IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is ISoftDeletable softDeletable)
            {
                softDeletable.IsDeleted = true;
                _context.Set<TEntity>().Update(entity);
            }
            else
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task<List<TResult>> QueryAsync<TResult>(
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, TResult>> selector = null!,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            , bool asNoTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return await query.Select(selector).ToListAsync();
        }

        public async Task<TResult?> QuerySingleAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query
                .Where(predicate)
                .Select(selector)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
