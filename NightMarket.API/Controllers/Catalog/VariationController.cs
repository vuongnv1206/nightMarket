using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Features.Variations.Requests.Queries;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariationController : BaseApiController
	{
		public VariationController(IMediator mediator) : base(mediator)
		{
		}


		[HttpGet]
		public async Task<ApiResponse<List<GetAllVariationDto>>> GetVariations()
		{
			var variantions = await _mediator.Send(new GetAllVariationRequest());
			return ApiResponse<List<GetAllVariationDto>>.Success(variantions);
		}


		[HttpGet("{id}")]
		public async Task<ApiResponse<GetAVariationDto>> GetAVariantion(int variationId)
		{
			var variationDto = await _mediator.Send(new GetAVariationRequest());
			return ApiResponse<GetAVariationDto>.Success(variationDto);
		}


		[HttpPost]
		public async Task<ActionResult<BaseCommandResponse>> CreateAProduct([FromBody] CreateAVariationDto variationDto)
		{
			var command = new CreateAVariationRequest { VariationDto = variationDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}


		//[HttpPut("{id}")]
		//public async Task<ActionResult<BaseCommandResponse>> UpdateAProduct([FromBody] UpdateAProductDto productDto)
		//{
		//	var command = new UpdateAProductRequest { ProductDto = productDto };
		//	var response = await _mediator.Send(command);
		//	return Ok(response);
		//}

		//[HttpDelete("{id}")]
		//public async Task<ActionResult<BaseCommandResponse>> DeleteAProduct(int productId)
		//{
		//	var command = new DeleteAProductRequest { ProductId = productId };
		//	var response = await _mediator.Send(command);
		//	return Ok(response);
		//}
	}
}
