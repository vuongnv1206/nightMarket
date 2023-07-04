
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : BaseApiController
	{
		public ProductController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ApiResponse<List<GetAllProductsDto>>> GetProducts()
		{
			var products = await _mediator.Send(new GetAllProductRequest());
			return ApiResponse<List<GetAllProductsDto>>.Success(products);
		}


		[HttpGet("{id}")]
		public async Task<ApiResponse<GetAProductDto>> GetAProduct(int productId)
		{
			var product = await _mediator.Send(new GetAProductRequest());
			return ApiResponse<GetAProductDto>.Success(product);
		}


		[HttpPost]
		public async Task<ActionResult<BaseCommandResponse>> CreateAProduct([FromBody] CreateAProductDto productDto)
		{
			var command = new CreateAProductRequest { ProductDto = productDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}


		[HttpPut("{id}")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateAProduct([FromBody] UpdateAProductDto productDto)
		{
			var command = new UpdateAProductRequest { ProductDto = productDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteAProduct(int productId)
		{
			var command = new DeleteAProductRequest { ProductId = productId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
