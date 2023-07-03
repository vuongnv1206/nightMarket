using NightMarket.Domain.Entities.PaymentBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.PaymentDto
{
	public class GetInfoPaymentDto
	{
		public int PaymentMethodId { get; set; }
		public string? Provider { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string AccountNumber { get; set; }
		public PaymentStatus Status { get; set; }
		public bool IsDefault { get; set; }
		public GetInfoPaymentMethodDto PaymentMethod { get; set; }
	}
}
