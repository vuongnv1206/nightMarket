using Microsoft.AspNetCore.Identity;
using NightMarket.Application.Interfaces.Identity;
using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Indentity
{
	public class UserServices : IUserServices
	{
		private readonly UserManager<ApplicationUsers> _userManager;

        public UserServices(UserManager<ApplicationUsers> userManager)
        {
			_userManager = userManager;
        }
        public async Task<List<ApplicationUsers>> GetAllUsers()
		{
			var users = await _userManager.GetUsersInRoleAsync("Employee");
			return users.Select(q => new ApplicationUsers
			{
				Id = q.Id,
				Email = q.Email,
				
			}).ToList();
		}

		public async Task<ApplicationUsers> GetUser(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			return new ApplicationUsers
			{
				UserName = user.UserName,
			};
		}
	}
}
