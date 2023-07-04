using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Identity
{
	public static class IdentityServicesRegistration
	{
		public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

			services.AddDbContext<IdentityDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"),
				b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)));

			services.AddIdentity<ApplicationUsers, IdentityRole>()
				.AddEntityFrameworkStores<IdentityDbContext>()
				.AddDefaultTokenProviders();

			//services.AddTransient<IAuthService, AuthService>();
			//services.AddTransient<IUserService, UserService>();

			//services.AddAuthentication(options =>
			//{
			//	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//})
			//	.AddJwtBearer(o =>
			//	{
			//		o.TokenValidationParameters = new TokenValidationParameters
			//		{
			//			ValidateIssuerSigningKey = true,
			//			ValidateIssuer = true,
			//			ValidateAudience = true,
			//			ValidateLifetime = true,
			//			ClockSkew = TimeSpan.Zero,
			//			ValidIssuer = configuration["JwtSettings:Issuer"],
			//			ValidAudience = configuration["JwtSettings:Audience"],
			//			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
			//		};
			//	});

			return services;
		}
	}
}
