using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Catalog
{
	public interface IVariationRepository : IGenericRepository<Variations>
	{
		Task<List<Variations>> GetVariationsOfProduct(int productId, params Expression<Func<Variations, object>>[]? includes);
	}
}
