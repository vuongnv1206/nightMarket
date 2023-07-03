using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ShoppingBundles;
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
        public string Name { get; set; }
        public string? Note { get; set; }
        public string Code { get; set; }
		public PromotionType Type { get; set; }
		public double Value { get; set; }
        public double MaximumValue { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public PromotionApplyTo ApplyTo { get; set; }
		public double MinimunOrderValue { get; set; }
        public int TotalUsageLimit { get; set; }
        public int LimitUsePerCustomer { get; set; }
        public bool IsEnabled { get; set; }

        public IEnumerable<CategoryPromotions> CategoryPromotions { get; set; }
		public IEnumerable<ProductPromotions> ProductPromotions { get; set; }
		public IEnumerable<UserPromotions> UserPromotions { get; set; }
        public IEnumerable<Orders> Orders { get; set; }


    }
}
