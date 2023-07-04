

namespace NightMarket.Application.DTOs.ShoppingBundles.CartItemDto
{
	public class UpdateCartItemDto 
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int? ProductItemId { get; set; }
		public double Price { get; set; }
		public double? CompareAtPrice { get; set; }
		public int Quantity { get; set; }

	}
}
