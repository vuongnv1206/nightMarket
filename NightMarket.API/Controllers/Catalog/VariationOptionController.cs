using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Application.Features.VariationOptions.Requests.Commands;
using NightMarket.Application.Features.VariationOptions.Requests.Queries;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Features.Variations.Requests.Queries;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariationOptionController : BaseApiController
	{
		public VariationOptionController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ApiResponse<List<GetVariationOptionDto>>> GetVariationOptionsByVariationId()
		{
			var variantionOptions = await _mediator.Send(new GetAllVariationOptionRequest());
			return ApiResponse<List<GetVariationOptionDto>>.Success(variantionOptions);
		}



		[HttpGet("/variationOptionId")]
		public async Task<ApiResponse<GetVariationOptionDto>> GetAVariantion(int variationOptionId)
		{
			var variantionOption = await _mediator.Send(new GetAVariationOptionRequest());
			return ApiResponse<GetVariationOptionDto>.Success(variantionOption);
		}

		//Create ben Variation roi

		[HttpPut("/variationOptionId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateAVariationOption([FromBody] UpdateAVariationOptionDto variationOptionDto)
		{
			var command = new UpdateAVariationOptionRequest { VariationOptionDto = variationOptionDto};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("/variationOptionId")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteAVariationOption(int variationOptionId)
		{
			var command = new DeleteAVariationOptionRequest { VariationOptionId = variationOptionId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
