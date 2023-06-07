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
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public bool IsDefault { get; set; }

        public Addresses Address { get; set; }
        public ApplicationUsers User { get; set; }

    }
}
