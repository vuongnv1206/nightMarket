using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NightMarket.Application.Extensions;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Persistence.Repositories.Persisence;
using NightMarket.Persistence.Repositories.Persisence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence
{
    public static class PersistenceServicesRegistration
	{
		public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));




			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IVariationRepository, VariationRepository>();
			services.AddScoped<IVariationOptionRepository, VariationOptionRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
			services.AddScoped<IProductCombinationRepository, ProductCombinationRepository>();

			services.AddScoped<ISortHelper<Categories>, SortHelper<Categories>>();
			services.AddScoped<ISortHelper<Products>, SortHelper<Products>>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();



			return services;
		}
	}
}
