using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductCoupons : BaseDomainEntity
	{
        public int ProductId { get; set; }
        public int CouponId { get; set; }
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Coupons> Coupons { get; set; }

    }
}
