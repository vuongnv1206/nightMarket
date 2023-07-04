using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
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

			this.SeedRoles(modelBuilder);
			// Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
			// tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
			// Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				var tableName = entityType.GetTableName();
				if (tableName.StartsWith("AspNet"))
				{
					entityType.SetTableName(tableName.Substring(6));
				}
			}
		}

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

			var result = await base.SaveChangesAsync();

			return result;
		}

		private void SeedRoles(ModelBuilder builder)
		{
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
				new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
				new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }
				);
		}
	}
}
