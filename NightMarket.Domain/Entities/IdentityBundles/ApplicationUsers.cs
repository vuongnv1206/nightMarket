using Microsoft.AspNetCore.Identity;
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
        public IEnumerable<Addresses> Addresses { get; set; }


    }
}
