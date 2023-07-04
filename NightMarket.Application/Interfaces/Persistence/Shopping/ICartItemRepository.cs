using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Shopping
{
	public interface ICartItemRepository : IGenericRepository<CartItems>
	{
	}
}
