using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.DTOs.Identity.AddressDto;
using NightMarket.Application.DTOs.Identity.UserDto;
using NightMarket.Application.DTOs.ShoppingBundles.OrderLineDto;
using NightMarket.Application.DTOs.ShoppingBundles.PaymentDto;
using NightMarket.Application.DTOs.ShoppingBundles.ShippingMethodDto;
using NightMarket.Domain.Enums;


namespace NightMarket.Application.DTOs.ShoppingBundles.OrderDto
{
	public class GetAOrderDto
	{
		public DateTime OrderDate { get; set; }
		public double Total { get; set; }
		public OrderStatus Status { get; set; }
        public GetInfoUserDto User { get; set; }
        public GetInfoAddressDto Address { get; set; }
        public GetAPromotionDto Promotion { get; set; }
		public GetInfoShippingMethodDto ShippingMethod { get; set; }
		public GetInfoPaymentDto Payment { get; set; }
		public IEnumerable<GetAOrderLineDto> OrderLines { get; set; }
	}
}
