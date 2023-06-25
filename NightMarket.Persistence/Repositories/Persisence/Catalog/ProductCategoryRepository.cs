using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class ProductCategoryRepository : GenericRepository<ProductCategories>, IProductCategoryRepository
	{	
		private readonly ApplicationDbContext _context;
		public ProductCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}

		public async Task<ProductCategories> FindAsync(int productId, int categoryId)
		{
			var productCategory = await _context.ProductCategories
				.FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId && pc.DeleteAt == null);

			return productCategory;
		}
	}
}
