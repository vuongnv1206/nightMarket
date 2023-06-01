using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductCollections : BaseDomainEntity
	{
        public int ProductId { get; set; }
        public int CollectionId { get; set; }

        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Collections> Collections { get; set; }
    }
}
