using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NightMarket.Domain.Common;
using NightMarket.Domain.Entities;
using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


			base.OnModelCreating(modelBuilder);

			
			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				var tableName = entityType.GetTableName();
				if (tableName.StartsWith("AspNet"))
				{
					entityType.SetTableName(tableName.Substring(6));
				}
			}
		}


		//IdentityBundles
		public DbSet<Addresses> Addresses { get; set; }
		public DbSet<UserAddresses> UserAddresses { get; set; }

		//ProductBundles
		public DbSet<Categories> Categories { get; set; }
		public DbSet<CategoryPromotions> CategoryPromotions { get; set; }
		public DbSet<Coupons> Coupons { get; set; }
		public DbSet<ProductConfigurations> ProductConfigurations { get; set; }
		public DbSet<ProductInventory> ProductInventories { get; set; }
		public DbSet<Products> Products { get; set; }
		public DbSet<ProductItems> ProductItems { get; set; }
		public DbSet<Promotions> Promotions { get; set; }
		public DbSet<VariationOptions> VariationOptions { get; set; }
		public DbSet<Variations> Variations { get; set; }
		public DbSet<Brands> Brands { get; set; }
		public DbSet<Suppliers> Suppliers { get; set; }

		


		//Others





		public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
		{
			foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
				.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
			{
				entry.Entity.LastModifiedDate = DateTime.Now;
				entry.Entity.LastModifiedBy = username;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
					entry.Entity.CreatedBy = username;
				}
				
			}

			foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
				.Where(q => q.State == EntityState.Deleted))
			{
				if (entry.State == EntityState.Deleted)
				{
					entry.Entity.DeleteAt = DateTime.Now;
				}

			}


			var result = await base.SaveChangesAsync();

			return result;
		}

		//private void SeedRoles(ModelBuilder builder)
		//{
		//	builder.Entity<IdentityRole>().HasData(
		//		new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
		//		new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
		//		new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }
		//		);
		//}
	}
}
