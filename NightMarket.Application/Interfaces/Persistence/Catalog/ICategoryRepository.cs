
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Catalog
{
    public interface ICategoryRepository : IGenericRepository<Categories>
	{
		Task<PagedList<Categories>> ListAsync(CategoryParameters parameters);
		Task<List<Categories>> GetCategoriesNotInProduct(CategoryParameters parameters);

		Task<List<Categories>> GetCategoriesOfProduct(int productId);

		Task<List<Categories>> GetCategoriesNotInPromotion(CategoryParameters parameters);

		Task<List<Categories>> GetCategoriesByPromotion(int promotionId);
	}
}
