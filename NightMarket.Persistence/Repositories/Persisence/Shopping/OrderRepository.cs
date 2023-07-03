using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Extensions;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence.Shopping;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Shopping
{
	public class OrderRepository : GenericRepository<Orders>, IOrderRepository
	{
		private readonly ISortHelper<Orders> _sortHelper;
		private readonly ApplicationDbContext _context;
		public OrderRepository(ApplicationDbContext dbContext, ISortHelper<Orders> sortHelper) : base(dbContext)
		{
			_sortHelper = sortHelper;
			_context = dbContext;
		}

		public async Task<PagedList<Orders>> ListAsync(OrderParameters parameters)
		{
			var items = await ListAsync(x => x.OrderLines,x => x.User);
			if (parameters.Status != null)
			{
				items = items.Where(c => c.Status == (OrderStatus)parameters.Status).ToList();
			}
			SearchByText(ref items, parameters.Text);
			FilterByCreated(ref items, parameters.Created);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return PagedList<Orders>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
		}

		private void SearchByText(ref List<Orders> orders, string? text)
		{
			if (!orders.Any() || string.IsNullOrWhiteSpace(text))
				return;
			orders = orders.Where(o => o.User.FirstName.ToLower().Contains(text.Trim().ToLower()) || o.User.LastName.ToLower().Contains(text.Trim().ToLower())).ToList();
		}

		private void FilterByCreated(ref List<Orders> orders, int? created)
		{
			if (!orders.Any() || created.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (created)
			{
				case 1:
					orders = orders.Where(c => c.DateCreated >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					orders = orders.Where(c => c.DateCreated >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					orders = orders.Where(c => c.DateCreated >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		public async Task<Orders> GetOrdersByIdAsync(int orderId)
		{
			var order = _context.Orders.Where(o => o.DeleteAt == null && o.Id == orderId)
				.Include(o => o.User)
				.Include(o => o.Address)
				.Include(o => o.Promotion)
				.Include(o => o.ShippingMethod)
				.Include(o => o.Payment)
				.Include(o => o.OrderLines).ThenInclude(ol => ol.Product)
				.Include(o => o.OrderLines).ThenInclude(ol => ol.ProductItem).ThenInclude(pi => pi.ProductCombinations).FirstOrDefault();

			return order;
		}
	}
}
