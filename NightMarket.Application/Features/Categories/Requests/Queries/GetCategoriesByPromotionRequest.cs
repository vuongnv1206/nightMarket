using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;


namespace NightMarket.Application.Features.Categories.Requests.Queries
{
	public class GetCategoriesByPromotionRequest : IRequest<List<GetAllCategoriesDto>>
	{
		public int PromotionId { get; set; }
	}
}
