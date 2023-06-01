using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class OrderDetails : BaseDomainEntity
	{
        public int OrderId { get; set; }
        public double Total { get; set; }
        
    }
}
