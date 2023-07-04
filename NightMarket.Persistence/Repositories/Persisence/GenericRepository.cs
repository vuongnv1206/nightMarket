using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
            return entities;
        }

        public async Task<bool> AnyAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {   
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
		    var entity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
			if (entity != null && entity.DeleteAt != null)
			{
				return null; // Return null if DeleteAt is not null
			}
			return entity;
		}

		public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) where TId : notnull
		{
			var query = _dbContext.Set<T>().AsQueryable();

			foreach (var includeExpression in includes)
			{
				query = query.Include(includeExpression);
			}

			var entity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);

			if (entity != null && entity.DeleteAt != null)
			{
				return null; // Return null if DeleteAt is not null
			}

			return entity;
		}


		public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>()
                .Where(e => e.DeleteAt == null).ToListAsync(cancellationToken);
		}

		public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
		{
			var query = _dbContext.Set<T>().Where(e => e.DeleteAt == null);

			foreach (var includeExpression in includes)
			{
				query = query.Include(includeExpression);
			}

			return await query.ToListAsync(cancellationToken);
		}


		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
			_dbContext.Entry(entity).State = EntityState.Modified;
			
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.UpdateRange(entities);
        }
    }
}
