using NightMarket.Domain.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class ShippingTracking : BaseDomainEntity
	{
		public int OrderId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public Orders Order { get; set; }
	}
}
