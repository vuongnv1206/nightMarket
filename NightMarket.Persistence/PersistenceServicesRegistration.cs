﻿using Microsoft.EntityFrameworkCore;
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
			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(
				   configuration.GetConnectionString("ApplicationConnectionString")));


			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			//services.AddScoped<IUnitOfWork, UnitOfWork>();

			

			return services;
		}
	}
}
