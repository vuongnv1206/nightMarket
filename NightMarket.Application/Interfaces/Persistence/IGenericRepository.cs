
using System.Linq.Expressions;


namespace NightMarket.Application.Interfaces.Persistence
{
    public interface IGenericRepository<T>  where T : class
	{
		Task<T?> GetByIdAsync<TId>(TId id) where TId : notnull;

		Task<T?> GetByIdAsync<TId>(TId id,params Expression<Func<T, object>>[] includes) where TId : notnull;

		Task<List<T>> ListAsync();
		
		Task<List<T>> ListAsync(params Expression<Func<T, object>>[] includes);
		Task<bool> AnyAsync<TId>(TId id);
		Task<int> CountAsync();
		Task<T> AddAsync(T entity);
		Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
		Task UpdateAsync(T entity);
		Task UpdateRangeAsync(IEnumerable<T> entities);
		Task DeleteAsync(T entity);
		Task DeleteRangeAsync(IEnumerable<T> entities);
		Task<int> SaveChangesAsync();

	}
}
