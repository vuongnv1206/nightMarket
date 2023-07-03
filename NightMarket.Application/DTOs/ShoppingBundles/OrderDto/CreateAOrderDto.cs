using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Domain.Entities.PaymentBundles;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.OrderDto
{
	public class CreateAOrderDto
	{
		public int UserId { get; set; }
		public DateTime OrderDate { get; set; }
		public int PaymentId { get; set; }
		//Địa chỉ nhận (nếu địa chỉ mới thì tạo mới địa chỉ trc)
		public int AddressId { get; set; }
		public int ShippingMethodId { get; set; }
		public double Total { get; set; }
		public OrderStatus Status { get; set; }
		public int? PromotionId { get; set; }
	}
}
