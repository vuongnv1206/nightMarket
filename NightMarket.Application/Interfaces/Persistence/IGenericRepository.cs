using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence
{
	public interface IGenericRepository<T>  where T : class
	{
		Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

		Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes) where TId : notnull;

		Task<List<T>> ListAsync(CancellationToken cancellationToken = default);

		Task<List<T>> ListAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
		Task<bool> AnyAsync<TId>(TId id,CancellationToken cancellationToken = default);
		Task<int> CountAsync(CancellationToken cancellationToken = default);
		Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
		Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
		Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
		Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
		Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
		Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

	}
}
