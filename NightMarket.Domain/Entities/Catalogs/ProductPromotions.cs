using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.Catalogs
{
	public class ProductPromotions : BaseDomainEntity
	{
		public int ProductId { get; set; }
		public int PromotionId { get; set; }
		public Products Product { get; set; }
		public Promotions Promotion { get; set; }
	}
}
