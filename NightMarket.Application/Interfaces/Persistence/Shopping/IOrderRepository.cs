using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Shopping
{
	public interface IOrderRepository : IGenericRepository<Orders>
	{
		Task<PagedList<Orders>> ListAsync(OrderParameters parameters);

		Task<Orders> GetOrdersByIdAsync(int orderId);
	}
}
