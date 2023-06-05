using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductInventory : BaseDomainEntity
	{
        public int ProductItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityOnOrder { get; set; }

    }
}
