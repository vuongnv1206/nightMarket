using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.ShippingMethodDto
{
	public class GetInfoShippingMethodDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string? Description { get; set; }
		public double ShippingCost { get; set; }
		public double DeliveryTime { get; set; }
	}
}
