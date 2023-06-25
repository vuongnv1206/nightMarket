using Microsoft.AspNetCore.Http;
using NightMarket.Application.Extensions;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Persistence.Repositories.Persisence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence
{
    public class UnitOfWork : IUnitOfWork
	{	
		private readonly ApplicationDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		private readonly IProductRepository _productRepository;
		private readonly IVariationRepository _variationRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IVariationOptionRepository _variationOptionRepository;
		private readonly IProductItemRepository _productItemRepository;
		private readonly IProductCombinationRepository _productCombinationRepository;
		private readonly IProductCategoryRepository _productCategoryRepository;
		private readonly IPromotionRepository _promotionRepository;
		private readonly IProductPromotionRepository _productPromotionRepository;
		private readonly ICategoryPromotionRepository _categoryPromotionRepository;
		private readonly IUserPromotionRepository _userPromotionRepository;

		private readonly ISortHelper<Categories> _categorySortHelper;
		private readonly ISortHelper<Products> _productSortHelper;
		private readonly ISortHelper<Promotions> _promotionSortHelper;
	
		public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
			_httpContextAccessor = httpContextAccessor;
        }
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context,_productSortHelper);

		public IVariationRepository VariationRepository => _variationRepository ?? new VariationRepository(_context);

		public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context,_categorySortHelper);

		public IVariationOptionRepository VariationOptionRepository => _variationOptionRepository ?? new VariationOptionRepository(_context);
		
		public IProductItemRepository ProductItemRepository => _productItemRepository ?? new ProductItemRepository(_context);

		public IProductCombinationRepository ProductCombinationRepository => _productCombinationRepository ?? new ProductCombinationRepository(_context);
		
		public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository ?? new ProductCategoryRepository(_context);

		public IPromotionRepository PromotionRepository => _promotionRepository ?? new PromotionRepository(_context,_promotionSortHelper);

		public IProductPromotionRepository ProductPromotionRepository => _productPromotionRepository ?? new ProductPromotionRepository(_context);

		public ICategoryPromotionRepository CategoryPromotionRepository => _categoryPromotionRepository ?? new CategoryPromotionRepository(_context);

		public IUserPromotionRepository UserPromotionRepository => _userPromotionRepository ?? new UserPromotionRepository(_context);

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save()
		{
			//var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

			await _context.SaveChangesAsync();
		}
	}
}
