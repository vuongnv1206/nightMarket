using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class Collections : BaseDomainEntity
	{
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
