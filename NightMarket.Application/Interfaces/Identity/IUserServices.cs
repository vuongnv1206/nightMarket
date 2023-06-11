using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Identity
{
	public interface IUserServices
	{
		Task<List<ApplicationUsers>> GetAllUsers();
		Task<ApplicationUsers> GetUser(string userId);
	}
}
