using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class Variations : BaseDomainEntity
	{
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public IEnumerable<VariationOptions> VariationOptions { get; set; }
    }
}
