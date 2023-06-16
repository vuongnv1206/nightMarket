using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class VariationOptions : BaseDomainEntity
	{
        public int VariationId { get; set; }
        public string Value { get; set; }
        public Variations Variation { get; set; }
		public IEnumerable<ProductCombinations> ProductCombinations { get; set; }

	}
}
