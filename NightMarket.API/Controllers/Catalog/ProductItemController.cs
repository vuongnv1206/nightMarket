using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.ProductItems.Requests.Commands;
using NightMarket.Application.Features.ProductItems.Requests.Queries;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductItemController : BaseApiController
	{
		public ProductItemController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ApiResponse<List<GetAllProductItemsDto>>> GetProductItems()
		{
			var productItems = await _mediator.Send(new GetAllProductItemsRequest());
			return ApiResponse<List<GetAllProductItemsDto>>.Success(productItems);
		}


		[HttpGet("/productItemId")]
		public async Task<ApiResponse<GetAProductItemDto>> GetAProductItem(int productItemId)
		{
			var productItem = await _mediator.Send(new GetAProductItemRequest { ProductItemId = productItemId });
			return ApiResponse<GetAProductItemDto>.Success(productItem);
		}

		//[HttpPost]
		//public async Task<ActionResult<BaseCommandResponse>> CreateListProductItems([FromBody] CreateAProductItemDto productItemDto)
		//{
		//	var command = new CreateAProductItemRequest { ProductItemDto = productItemDto };
		//	var response = await _mediator.Send(command);
		//	return Ok(response);
		//}

		[HttpPut("/productItemId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateAProductItems([FromBody] UpdateAProductItemDto productItemDto)
		{
			var command = new UpdateAProductItemRequest { ProductItemDto = productItemDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		
	}
}
