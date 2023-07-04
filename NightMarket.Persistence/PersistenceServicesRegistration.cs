using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NightMarket.Application.Extensions;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Interfaces.Persistence.Shopping;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Persistence.Repositories.Persisence;
using NightMarket.Persistence.Repositories.Persisence.Catalog;
using NightMarket.Persistence.Repositories.Persisence.Shopping;

namespace NightMarket.Persistence
{
    public static class PersistenceServicesRegistration
	{
		public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));




			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			
			//Catalog
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IVariationRepository, VariationRepository>();
			services.AddScoped<IVariationOptionRepository, VariationOptionRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
			services.AddScoped<IProductCombinationRepository, ProductCombinationRepository>();
			services.AddScoped<IProductItemRepository, ProductItemRepository>();
			services.AddScoped<IPromotionRepository,PromotionRepository>();
			services.AddScoped<IUserPromotionRepository, UserPromotionRepository>();
			services.AddScoped<IProductPromotionRepository, ProductPromotionRepository>();
			services.AddScoped<ICategoryPromotionRepository, CategoryPromotionRepository>();

			//SortHelper
			services.AddScoped<ISortHelper<Categories>, SortHelper<Categories>>();
			services.AddScoped<ISortHelper<Products>, SortHelper<Products>>();
			services.AddScoped<ISortHelper<Promotions>, SortHelper<Promotions>>();
			services.AddScoped<ISortHelper<Orders>, SortHelper<Orders>>();

			//UnitOfWork
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			//ShoppingCart
			services.AddScoped<ICartItemRepository, CartItemRepository>();
			services.AddScoped<ICartRepository, CartRepository>();
			services.AddScoped<IOrderLineRepository, OrderLineRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IShippingMethodRepository, ShippingMethodRepository>();
			services.AddScoped<IUserReviewRepository, UserReviewRepository>();


			return services;
		}
	}
}
