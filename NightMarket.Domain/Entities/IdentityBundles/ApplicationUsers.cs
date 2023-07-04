using Microsoft.AspNetCore.Identity;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.IdentityBundles
{
	public class ApplicationUsers : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string? CompanyName { get; set; }
        public IEnumerable<Addresses> Addresses { get; set; }
        public IEnumerable<UserPromotions> UserPromotions { get; set; }
        public Carts Cart { get; set; }

    }
}
