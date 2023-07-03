using NightMarket.Application.DTOs.Catalogs.ProductDto;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;



namespace NightMarket.Application.DTOs.ShoppingBundles.CartItemDto
{
    public class GetCartItemDto
	{
        public int Id { get; set; }
        public int CartId { get; set; }
		public int ProductId { get; set; }
		public int? ProductItemId { get; set; }
		public int Quantity { get; set; }
		public ProductCartDto Product { get; set; }
		public IEnumerable<ProductItemCartDto> ProductItems { get; set; }
	
	}
}
