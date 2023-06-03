using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NightMarket.Application.Contracts.Persistence;
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
			//services.AddDbContext<ApplicationDbContext>(options =>
			//   options.UseSqlServer(
			//	   configuration.GetConnectionString("ApplicationConnectionString")));

			
				IConfigurationRoot configurationRoot = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
				var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
				var connectionString = configurationRoot.GetConnectionString("ApplicationConnectionString");
				builder.UseSqlServer(connectionString);


			


			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			//services.AddScoped<IUnitOfWork, UnitOfWork>();



			return services;
		}
	}
}
