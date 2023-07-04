using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.PaymentDto
{
	public class GetInfoPaymentMethodDto
	{
		public string Name { get; set; }
		public string? Description { get; set; }
	}
}
