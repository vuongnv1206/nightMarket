using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class UserPromotionRepository : GenericRepository<UserPromotions>, IUserPromotionRepository
	{
		public UserPromotionRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
