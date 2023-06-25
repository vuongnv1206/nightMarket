using NightMarket.Application.Helpers;
using NightMarket.Application.Models.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Catalog
{
    public interface IProductRepository : IGenericRepository<Products>
    {
		Task<PagedList<Products>> ListAsync(ProductParameters parameters);

		Task<List<Products>> GetProductsNotInCategory(ProductParameters parameters);

		Task<List<Products>> GetProductsByCategory(int categoryId);

		Task<Products> GetProductByIdAsync(int productId);


		Task<List<Products>> GetProductsNotInPromotion(ProductParameters parameters);

		Task<List<Products>> GetProductsByPromotion(int promotionId);
	}
}
