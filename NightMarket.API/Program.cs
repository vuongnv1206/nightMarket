using Microsoft.OpenApi.Models;
using NightMarket.API.Middleware;
using NightMarket.Application;
using NightMarket.Infrastructure;
using NightMarket.Persistence;
using NLog;

namespace NightMarket.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var configuration = builder.Configuration;

			builder.Services.ConfigureApplicationServices();
			builder.Services.ConfigureInfrastructureServices(configuration);
			builder.Services.ConfigurePersistenceServices(configuration);
			builder.Services.ConfigureIdentityServices(configuration);
			// Add services to the container.

			builder.Services.AddControllers();

			

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			//Xoa dong nay ->
			//builder.Services.AddSwaggerGen();
			////Them doan nay ->
			builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type=ReferenceType.SecurityScheme,
									Id="Bearer"
								}
							},
							new string[]{}
							}
						});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseHttpsRedirection();

			app.UseAuthentication();   // Phục hồi thông tin đăng nhập (xác thực)

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}