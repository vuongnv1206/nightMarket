using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class WishLists : BaseDomainEntity
	{
        public int UserId{ get; set; }
        public string Name { get; set; }
        public ApplicationUsers User { get; set; }

    }
}
