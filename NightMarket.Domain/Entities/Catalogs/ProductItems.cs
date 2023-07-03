using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ShoppingBundles;
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
		public double? CompareAtPrice { get; set; }
        public bool? TrackInventory { get; set; }
        public Products Product { get; set; }
		public IEnumerable<ProductCombinations> ProductCombinations { get; set; }
        public IEnumerable<CartItems> CartItems { get; set; }
		public IEnumerable<OrderLines> OrderLines { get; set; }
	}
}
