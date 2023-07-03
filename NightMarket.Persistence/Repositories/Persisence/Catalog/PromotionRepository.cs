using NightMarket.Application.Extensions;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
    public class PromotionRepository : GenericRepository<Promotions>, IPromotionRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly ISortHelper<Promotions> _sortHelper;
		public PromotionRepository(ApplicationDbContext dbContext, ISortHelper<Promotions> sortHelper) : base(dbContext)
		{
			_context = dbContext;
			_sortHelper = sortHelper;
		}

		public async Task<PagedList<Promotions>> ListAsync(PromotionParameters parameters)
		{
			var items = await ListAsync();

			if (parameters.Type != null)
			{
				items = items.Where(c => c.Type == (PromotionType)parameters.Type).ToList();
			}
			if (parameters.ApplyTo != null)
			{
				items = items.Where(c => c.ApplyTo == (PromotionApplyTo)parameters.ApplyTo).ToList();
			}

			SearchByText(ref items, parameters.Text);

			if (parameters.IsEnabled != null)
			{
				items = items.Where(p => p.IsEnabled).ToList();
			}
			if (parameters.StartDate.HasValue)
			{
				items = items.Where(p => p.StartDate >= parameters.StartDate).ToList();
			}
			if (parameters.EndDate.HasValue)
			{
				items = items.Where(p => p.EndDate <= parameters.EndDate).ToList();
			}



			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return PagedList<Promotions>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
		}
		private void SearchByText(ref List<Promotions> promotions, string? text)
		{
			if (!promotions.Any() || string.IsNullOrWhiteSpace(text))
				return;
			promotions = promotions.Where(o => o.Name.ToLower().Contains(text.Trim().ToLower())).ToList();
		}
	}
}
