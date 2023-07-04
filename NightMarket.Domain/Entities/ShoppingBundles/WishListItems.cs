using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class WishListItems : BaseDomainEntity
	{
        public int WishListId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductItemId { get; set; }
        public WishLists WishList { get; set; }
        public Products Product { get; set; }
        public ProductItems ProductItems { get; set; }
    }
}
