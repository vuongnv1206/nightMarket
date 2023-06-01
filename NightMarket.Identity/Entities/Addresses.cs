using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Identity.Entities
{
	public class Addresses : BaseDomainEntity
	{
        public int UserId { get; set; }
        public int? UnitNumber { get; set; }
        public int? StreetNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? ZipCode { get; set; }
        public ApplicationUsers User { get; set; }
    }
}
