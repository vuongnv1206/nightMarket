using NightMarket.Domain.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
    public class Promotions : BaseDomainEntity
    {
		public string Code { get; set; }
		public PromotionType Type { get; set; }
		public double Value { get; set; }
		public string? Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public  IEnumerable<CategoryPromotions> CategoryPromotions { get; set; }

	}
}
