using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Interfaces.Persistence.Shopping;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Shopping
{
	public class CartRepository : GenericRepository<Carts>, ICartRepository
	{
		private readonly ApplicationDbContext _context;
		public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_context = dbContext;
		}

		public async Task<Carts> GetCartInclude(int cartId)
		{
			var cart = _context.Carts
			.Where(c => c.Id == cartId && c.DeleteAt == null)
			.Include(c => c.CartItems.Where(ci => ci.DeleteAt == null)).ThenInclude(ci => ci.Product)
			.Include(c => c.CartItems.Where(ci => ci.DeleteAt == null)).ThenInclude(ci => ci.ProductItem)
			.ThenInclude(pi => pi.Product)
			.ThenInclude(p => p.Variations.Where(v => v.DeleteAt == null)).ThenInclude(v => v.VariationOptions.Where(vo => vo.DeleteAt == null))
			.FirstOrDefault();
			return cart;






		}
	}
}
