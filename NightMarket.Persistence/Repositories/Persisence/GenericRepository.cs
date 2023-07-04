using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
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
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> AnyAsync<TId>(TId id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {   
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull
        {
		    var entity = await _dbContext.Set<T>().FindAsync(new object[] { id });
			if (entity != null && entity.DeleteAt != null)
			{
				return null; // Return null if DeleteAt is not null
			}
			return entity;
		}

		public async Task<T?> GetByIdAsync<TId>(TId id, params Expression<Func<T, object>>[] includes) where TId : notnull
		{
			var query = _dbContext.Set<T>().AsQueryable();

			foreach (var includeExpression in includes)
			{
				query = query.Include(includeExpression);
			}

			var entity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));

			if (entity != null && entity.DeleteAt != null)
			{
				return null; // Return null if DeleteAt is not null
			}

			return entity;
		}



		public async Task<List<T>> ListAsync()
        {
            return await _dbContext.Set<T>()
                .Where(e => e.DeleteAt == null).ToListAsync();
		}

		public async Task<List<T>> ListAsync(params Expression<Func<T, object>>[] includes)
		{
			var query = _dbContext.Set<T>().Where(e => e.DeleteAt == null);

            foreach (var includeExpression in includes)
            {
                query = query.Include(includeExpression);
            }
            return await query.ToListAsync();
		}

		public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
			_dbContext.Entry(entity).State = EntityState.Modified;
			
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities);
        }
    }
}
