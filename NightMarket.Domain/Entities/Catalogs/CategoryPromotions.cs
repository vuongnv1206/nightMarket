using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class CategoryPromotions : BaseDomainEntity
	{
        public int CategoryId { get; set; }
        public int PromotionId { get; set; }
        public Categories Category { get; set; }
        public Promotions Promotion { get; set; }
    }
}
