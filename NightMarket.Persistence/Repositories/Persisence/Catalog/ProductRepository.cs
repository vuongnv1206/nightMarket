using Microsoft.EntityFrameworkCore;
using NightMarket.Application.Extensions;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Enums;
using NightMarket.Persistence.Repositories.Persisence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
		private readonly ISortHelper<Products> _sortHelper;
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext dbContext, ISortHelper<Products> sortHelper) : base(dbContext)
        {
			_sortHelper = sortHelper;
			_context = dbContext;
		}

		public async Task<PagedList<Products>> ListAsync(ProductParameters parameters)
		{
			var items = await ListAsync();

			if (parameters.Status != null)
			{
				items = items.Where(c => c.Status == (ProductStatus)parameters.Status).ToList();
			}

			SearchByText(ref items, parameters.Text);


			FilterByPublished(ref items, parameters.Published);
			FilterByCreated(ref items, parameters.Created);
			FilterByModified(ref items, parameters.Modified);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return PagedList<Products>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
		}

		private void SearchByText(ref List<Products> products, string? text)
		{
			if (!products.Any() || string.IsNullOrWhiteSpace(text))
				return;
			products = products.Where(o => o.Name.ToLower().Contains(text.Trim().ToLower()) || o.ShortDesc.ToLower().Contains(text.Trim().ToLower())
			|| o.LongDesc.ToLower().Contains(text.Trim().ToLower())).ToList();
		}



		private void FilterByPublished(ref List<Products> products, int? published)
		{
			if (!products.Any() || published.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (published)
			{
				case 1:
					products = products.Where(c => c.PublishDate >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					products = products.Where(c => c.PublishDate >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					products = products.Where(c => c.PublishDate >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		private void FilterByCreated(ref List<Products> products, int? created)
		{
			if (!products.Any() || created.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (created)
			{
				case 1:
					products = products.Where(c => c.DateCreated >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					products = products.Where(c => c.DateCreated >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					products = products.Where(c => c.DateCreated >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		private void FilterByModified(ref List<Products> products, int? modified)
		{
			if (!products.Any() || modified.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (modified)
			{
				case 1:
					products = products.Where(c => c.LastModifiedDate >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					products = products.Where(c => c.LastModifiedDate >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					products = products.Where(c => c.LastModifiedDate >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		public async Task<List<Products>> GetProductsNotInCategory(ProductParameters parameters)
		{	
			var items = _context.Products.Include(x => x.ProductCategories.Where(pc => pc.DeleteAt == null)).Where(p => p.DeleteAt == null).ToList();

			items = items.Where(p => p.ProductCategories
										.Any(pc => pc.CategoryId != parameters.ObjectId && pc.ProductId != p.Id))
										.ToList();

			if (parameters.Status != null)
			{
				items = items.Where(p => p.Status == (ProductStatus)parameters.Status).ToList();
			}
			

			SearchByText(ref items, parameters.Text);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return items;
		}

		public async Task<List<Products>> GetProductsByCategory(int categoryId)
		{
			var products = _context.Products.Include(x => x.ProductCategories.Where(pc => pc.DeleteAt == null))
											.Where(p => p.DeleteAt == null).ToList();

			products = products.Where(p => p.ProductCategories
								.Any(pc => pc.CategoryId == categoryId))
								.ToList();

			return products;
		}

		public async Task<Products> GetProductByIdAsync(int productId)
		{
			var product =  _context.Products.Where(p => p.DeleteAt == null && p.Id == productId)
				.Include(x => x.ProductItems.Where(pi => pi.DeleteAt == null))
				.Include(x => x.Variations.Where(v => v.DeleteAt == null))
				.ThenInclude(x => x.VariationOptions.Where(vo => vo.DeleteAt == null)).FirstOrDefault();

			return product;
		}

		public async Task<List<Products>> GetProductsNotInPromotion(ProductParameters parameters)
		{
			var items = _context.Products.Include(x => x.ProductPromotions.Where(pp => pp.DeleteAt == null)).Where(p => p.DeleteAt == null).ToList();

			items = items.Where(p => p.ProductPromotions
										.Any(pc => pc.PromotionId != parameters.ObjectId && pc.ProductId != p.Id))
										.ToList();

			if (parameters.Status != null)
			{
				items = items.Where(p => p.Status == (ProductStatus)parameters.Status).ToList();
			}
			

			SearchByText(ref items, parameters.Text);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return items;
		}

		public async Task<List<Products>> GetProductsByPromotion(int promotionId)
		{
			var products = _context.Products.Include(x => x.ProductPromotions.Where(pp => pp.DeleteAt == null)).Where(p => p.DeleteAt == null).ToList();

			products = products
			.Where(p => p.ProductPromotions.Any(pc => pc.PromotionId == promotionId))
			.ToList();

			return products;
		}
	}
}
