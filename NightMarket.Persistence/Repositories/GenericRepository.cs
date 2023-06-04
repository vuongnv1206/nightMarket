using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
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
			_dbContext.Set<T>().Remove(entity);
		}

		public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
		{
			_dbContext.Set<T>().RemoveRange(entities);
		}

		public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
		{
			return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
		}

		public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
		{
			return await _dbContext.Set<T>().ToListAsync(cancellationToken);
		}

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
		{
			_dbContext.Update(entity);
		}

		public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
		{
			_dbContext.UpdateRange(entities);
		}
	}
}
