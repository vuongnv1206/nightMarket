using Microsoft.EntityFrameworkCore;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.Extensions;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Models.Parameters;
using NightMarket.Application.Models.Parameters.Common;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
	{
		private readonly ISortHelper<Categories> _sortHelper;
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext dbContext, ISortHelper<Categories> sortHelper) : base(dbContext)
		{
			_sortHelper = sortHelper;
			_context = dbContext;
		}

		public async Task<PagedList<Categories>> ListAsync(CategoryParameters parameters)
		{
			var items = await ListAsync();

			if (parameters.Status != null)
			{
				items =  items.Where(c => c.Status == (CategoryStatus)parameters.Status).ToList();
			}

			SearchByText(ref items, parameters.Text);
			

			FilterByPublished(ref items, parameters.Published);
			FilterByCreated(ref items, parameters.Created);
			FilterByModified(ref items, parameters.Modified);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return PagedList<Categories>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
		}


		private void SearchByText(ref List<Categories> categories, string? text)
		{
			if (!categories.Any() || string.IsNullOrWhiteSpace(text))
				return;
			categories = categories.Where(o => o.Name.ToLower().Contains(text.Trim().ToLower()) || o.Description.ToLower().Contains(text.Trim().ToLower())).ToList();
		}

	

		private void FilterByPublished(ref List<Categories> categories, int? published)
		{
			if (!categories.Any() || published.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (published)
			{
				case 1:
					categories = categories.Where(c => c.PublishDate >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					categories = categories.Where(c => c.PublishDate >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					categories = categories.Where(c => c.PublishDate >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		private void FilterByCreated(ref List<Categories> categories, int? created)
		{
			if (!categories.Any() || created.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (created)
			{
				case 1:
					categories = categories.Where(c => c.DateCreated >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					categories = categories.Where(c => c.DateCreated >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					categories = categories.Where(c => c.DateCreated >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		private void FilterByModified(ref List<Categories> categories, int? modified)
		{
			if (!categories.Any() || modified.HasValue)
				return;

			var currentDate = DateTime.Now.Date;

			switch (modified)
			{
				case 1:
					categories = categories.Where(c => c.LastModifiedDate >= currentDate.AddDays(-1)).ToList();
					break;
				case 7:
					categories = categories.Where(c => c.LastModifiedDate >= currentDate.AddDays(-7)).ToList();
					break;
				case 30:
					categories = categories.Where(c => c.LastModifiedDate >= currentDate.AddDays(-30)).ToList();
					break;
			}
		}

		public async Task<List<Categories>> GetCategoriesOfProduct(int productId)
		{	
			var categories =  _context.Categories.Where(p => p.ProductCategories.Any(pc => pc.ProductId == productId && pc.DeleteAt == null))
			.ToList();

			return categories;
		}

		public async Task<List<Categories>> GetCategoriesNotInProduct(CategoryParameters parameters)
		{
			var items = _context.Categories.Include(x => x.ProductCategories).Where(p => p.DeleteAt == null).ToList();

			items = items.Where(c => _context.ProductCategories
										.Any(pc => pc.ProductId != parameters.ObjectId && pc.CategoryId != c.Id))
										.ToList();

			if (parameters.Status != null)
			{
				items = items.Where(p => p.Status == (CategoryStatus)parameters.Status).ToList();
			}


			SearchByText(ref items, parameters.Text);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return items;
		}

		public async Task<List<Categories>> GetCategoriesNotInPromotion(CategoryParameters parameters)
		{
			var items = _context.Categories.Include(x => x.CategoryPromotions).Where(p => p.DeleteAt == null).ToList();

			items = items.Where(c => _context.CategoryPromotions
										.Any(pc => pc.PromotionId != parameters.ObjectId && pc.CategoryId != c.Id))
										.ToList();

			if (parameters.Status != null)
			{
				items = items.Where(p => p.Status == (CategoryStatus)parameters.Status).ToList();
			}


			SearchByText(ref items, parameters.Text);

			items = _sortHelper.ApplySort(items, parameters.OrderBy).ToList();

			return items;
		}

		public async Task<List<Categories>> GetCategoriesByPromotion(int promotionId)
		{
			var categories = _context.Categories.Include(x => x.CategoryPromotions).Where(p => p.DeleteAt == null).ToList();

			categories = categories
			.Where(p => p.CategoryPromotions.Any(pc => pc.PromotionId == promotionId))
			.ToList();

			return categories;
		}
	}
}
