using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class Carts : BaseDomainEntity
	{
        public string UserId { get; set; }
        public ApplicationUsers User { get; set; }
        public IEnumerable<CartItems> CartItems { get; set; }

    }
}
