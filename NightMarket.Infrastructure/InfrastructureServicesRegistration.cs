using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NightMarket.Infrastructure.Logger.Services;
using NightMarket.Infrastructure.MailKit.Models;
using NightMarket.Infrastructure.MailKit.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{

			//Add Email Configs
			var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
			services.AddSingleton(emailConfig);
			services.AddScoped<IEmailService, EmailService>();

			//Add config for required Email
			services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = true);


			//Nlog
			//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
			services.AddSingleton<ILoggerManager, LoggerManager>();


			return services;
			
		}
	}
}
