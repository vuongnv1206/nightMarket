using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.IdentityBundles
{
	public class UserAddresses : BaseDomainEntity
	{
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public bool IsDefault { get; set; }

        public IEnumerable<Addresses> Addresses { get; set; }

    }
}
