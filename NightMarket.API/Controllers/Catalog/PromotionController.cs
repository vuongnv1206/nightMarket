using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.Features.Categories.Requests.Queries;
using NightMarket.Application.Features.Promotions.Requests.Commands;
using NightMarket.Application.Features.Promotions.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
    [Route("api/[controller]")]
	[ApiController]
	public class PromotionController : BaseApiController
	{
		public PromotionController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ApiResponse<PagedList<GetPromotionsDto>>> GetCategories([FromQuery] PromotionParameters parameters)
		{

			var promotions = await _mediator.Send(new GetAllPromotionsRequest { Parameters = parameters});
			var metadata = new
			{
				promotions.TotalCount,
				promotions.PageSize,
				promotions.CurrentPage,
				promotions.TotalPages,
				promotions.HasNext,
				promotions.HasPrevious
			};
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

			return ApiResponse<PagedList<GetPromotionsDto>>.Success(promotions);
		}


		[HttpGet("/promotionId")]
		public async Task<ApiResponse<GetAPromotionDto>> GetAPromotion(int promotionId)
		{
			var promotion = await _mediator.Send(new GetAPromotionsRequest { PromotionId = promotionId });
			return ApiResponse<GetAPromotionDto>.Success(promotion);
		}

		




		[HttpPost("create")]
		public async Task<ActionResult<BaseCommandResponse>> CreatePromotion([FromBody] CreateAPromotionDto promotionDto)
		{
			var command = new CreateAPromotionRequest { PromotionDto = promotionDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		



		[HttpPut("/promotionId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateAPromotion([FromBody] UpdateAPromotionDto promotionDto)
		{
			var command = new UpdateAPromotionRequest { PromotionDto = promotionDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("/promotionId")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteAPromotion(int promotionId)
		{
			var command = new DeleteAPromotionRequest { PromotionId = promotionId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		

	}
}
