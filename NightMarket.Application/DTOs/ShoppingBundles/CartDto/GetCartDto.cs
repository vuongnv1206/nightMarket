using NightMarket.Application.DTOs.ShoppingBundles.CartItemDto;
using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.CartDto
{
	public class GetCartDto
	{	
		public int Id { get; set; }
		public IEnumerable<GetCartItemDto> CartItemDtos { get; set; }
	}
}
