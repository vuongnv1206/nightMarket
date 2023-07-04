using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class VariationRepository : GenericRepository<Variations>,IVariationRepository
	{	
		private readonly ApplicationDbContext _context;
		public VariationRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}

		public Task<List<Variations>> GetVariationsOfProduct(int productId, params Expression<Func<Variations, object>>[]? includes)
		{
			IQueryable<Variations> query = _context.Variations.Where(v => v.ProductId == productId && v.DeleteAt == null);

			if (includes != null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return query.ToListAsync();
		}
	}
}
