using NightMarket.Application;
using NightMarket.Identity;
using NightMarket.Infrastructure;
using NightMarket.Persistence;

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
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();   // Phục hồi thông tin đăng nhập (xác thực)

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}