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
	public class GetOrdersDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
		public OrderStatus Status { get; set; }
        public int CountItems { get; set; }
		public double Total { get; set; }
	}
}
