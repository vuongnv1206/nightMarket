using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.CartItemDto
{
	public class CreateACartItemDto
	{
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int? ProductItemId { get; set; }
		public int Quantity { get; set; }
	}
}
