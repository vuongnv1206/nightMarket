using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class VariationRepository : GenericRepository<Variations>,IVariationRepository
	{
		public VariationRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
