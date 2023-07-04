using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Catalog
{
	public interface IProductCategoryRepository : IGenericRepository<ProductCategories>
	{
		Task<ProductCategories> FindAsync(int productId,int categoryId);
	}
}
