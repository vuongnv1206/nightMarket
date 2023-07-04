using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class Variations : BaseDomainEntity
	{
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
