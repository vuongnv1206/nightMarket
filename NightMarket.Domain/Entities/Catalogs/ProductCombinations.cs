using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.Catalogs
{
	public class ProductCombinations : BaseDomainEntity
	{
        public int ProductItemId { get; set; }
        public int VariationOptionId { get; set; }
        public ProductItems ProductItem { get; set; }
        public VariationOptions VariationOption { get; set; }
    }
}
