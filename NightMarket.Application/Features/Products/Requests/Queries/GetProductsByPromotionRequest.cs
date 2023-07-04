using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;


namespace NightMarket.Application.Features.Products.Requests.Queries
{
	public class GetProductsByPromotionRequest : IRequest<List<GetAllProductsDto>>
	{
		public int PromotionId { get; set; }
	}
}
