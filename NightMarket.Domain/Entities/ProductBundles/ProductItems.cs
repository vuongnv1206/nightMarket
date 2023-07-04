using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductItems : BaseDomainEntity
	{
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Location { get; set; }
		public int? DiscountId { get; set; }

        public IEnumerable<ProductConfigurations> ProductConfigurations { get; set; }
    }
}
