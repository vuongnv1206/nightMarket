using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class ShippingMethods : BaseDomainEntity
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public double ShippingCost { get; set; }
		//time giao hàng dự kiến
		public double DeliveryTime { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
    }
}
