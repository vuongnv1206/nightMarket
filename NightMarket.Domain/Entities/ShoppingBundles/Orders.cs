using NightMarket.Domain.Common;
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
        public int ProductItemId { get; set; }
        public DateTime OrderDate { get; set; }
        public int PaymenId { get; set; }
        public int ShipmentId { get; set; }
        public double Total { get; set; }
        public OrderStatus Status { get; set; }

        public ProductItems ProductItems { get; set; }
        
    }
}
