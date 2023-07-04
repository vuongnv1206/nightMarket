using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Domain.Entities.PaymentBundles;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class Orders : BaseDomainEntity
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
		public ApplicationUsers User { get; set; }
		public Addresses Address { get; set; }
		public Promotions Promotion { get; set; }
        public ShippingMethods ShippingMethod { get; set; }
        public Payments Payment { get; set; }
        public IEnumerable<OrderLines> OrderLines { get; set; }


    }
}
