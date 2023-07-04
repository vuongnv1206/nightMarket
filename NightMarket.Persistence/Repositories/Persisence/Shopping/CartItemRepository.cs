using NightMarket.Application.Interfaces.Persistence.Shopping;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Shopping
{
	public class CartItemRepository : GenericRepository<CartItems>, ICartItemRepository
	{
		public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
