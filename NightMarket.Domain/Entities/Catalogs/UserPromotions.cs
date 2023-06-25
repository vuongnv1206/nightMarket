using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.Catalogs
{
	public class UserPromotions : BaseDomainEntity
	{
		public string UserId { get; set; }
		public int PromotionId { get; set; }
        public bool IsActived { get; set; }
        public ApplicationUsers User { get; set; }
		public Promotions Promotion { get; set; }
	}
}
